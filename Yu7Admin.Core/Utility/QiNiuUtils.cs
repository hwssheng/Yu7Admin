/********************************************************************************  
 * NameSpace:    Yu7Admin.Core.Utility
 * FileName:     QiNiuUtils 
 * Create By:    Yu7.work
 * Email:        hws_1230@126.com
 * Create Time:  2020/1/16 18:14:20
 
 * Description:
 * 
 
 ********************************************************************************/
using Qiniu.IO;
using Qiniu.IO.Model;
using Qiniu.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yu7Admin.Core.Models; 


namespace Yu7Admin.Core.Utility
{
    public class QiNiuUtils
    {
        public string QiNiuInfo_AccessKey { get; set; }
        public string QiNiuInfo_SecretKey { get; set; }

        public QiNiuUtils(string AccessKey,string SecretKey)
        {
            QiNiuInfo_AccessKey = AccessKey;
            QiNiuInfo_SecretKey = SecretKey;
        }
        /// <summary>
        /// 上传
        /// </summary>
        /// <param name="stream">图片</param>
        /// <param name="fileName">文件名</param>
        /// <param name="path">目标目录</param>
        /// <returns></returns>
        public QiNiu UploadImgToQiNiu(byte[] stream, string fileName,string path)
        {
            Mac mac = new Mac(QiNiuInfo_AccessKey, QiNiuInfo_SecretKey);
            // 上传策略，参见 
            // https://developer.qiniu.com/kodo/manual/put-policy
            PutPolicy putPolicy = new PutPolicy();
            // 如果需要设置为"覆盖"上传(如果云端已有同名文件则覆盖)，请使用 SCOPE = "BUCKET:KEY"
            // putPolicy.Scope = bucket + ":" + saveKey;
            var saveKey = string.Format("{1}/{0}/", DateTime.Now.ToString("yyyy/MM/dd"),path) + fileName;
            putPolicy.Scope = "blog:" + saveKey;
            // 上传策略有效期(对应于生成的凭证的有效期)          
            putPolicy.SetExpires(3600);
            // 上传到云端多少天后自动删除该文件，如果不设置（即保持默认默认）则不删除
            // putPolicy.DeleteAfterDays = 1;
            string jstr = putPolicy.ToJsonString();
            //获取上传凭证
            var uploadToken = Auth.CreateUploadToken(mac, jstr);
            UploadManager um = new UploadManager();

            var result = um.UploadData(stream, saveKey, uploadToken);

            if (result.Code == 200)
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<QiNiu>(result.Text);
            }
            return null;
        }
    }
}
