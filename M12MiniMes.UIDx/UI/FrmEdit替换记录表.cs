using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using WHC.Pager.Entity;
using WHC.Dictionary;
using WHC.Framework.BaseUI;
using WHC.Framework.Commons;
using WHC.Framework.ControlUtil;
using DevExpress.XtraLayout;
using DevExpress.XtraEditors;

using M12MiniMes.BLL;
using M12MiniMes.Entity;

namespace M12MiniMes.UI
{
    /// <summary>
    /// 替换记录表
    /// </summary>	
    public partial class FrmEdit替换记录表 : BaseEditForm
    {
    	/// <summary>
        /// 创建一个临时对象，方便在附件管理中获取存在的GUID
        /// </summary>
    	private 替换记录表Info tempInfo = new 替换记录表Info();
    	
        public FrmEdit替换记录表()
        {
            InitializeComponent();
        }
                
        /// <summary>
        /// 实现控件输入检查的函数
        /// </summary>
        /// <returns></returns>
        public override bool CheckInput()
        {
            bool result = true;//默认是可以通过

            #region MyRegion
            #endregion

            return result;
        }

        /// <summary>
        /// 初始化数据字典
        /// </summary>
        private void InitDictItem()
        {
			//初始化代码
        }                        

        /// <summary>
        /// 数据显示的函数
        /// </summary>
        public override void DisplayData()
        {
            InitDictItem();//数据字典加载（公用）

            if (!string.IsNullOrEmpty(ID))
            {
                #region 显示信息
                替换记录表Info info = BLLFactory<替换记录表>.Instance.FindByID(ID);
                if (info != null)
                {
                	tempInfo = info;//重新给临时对象赋值，使之指向存在的记录对象
                	
                	txt替换时间.SetDateTime(info.替换时间);	
                      txt生产批次号.Text = info.生产批次号;
                       txt物料guid.Text = info.物料guid;
                       txt替换前治具guid.Text = info.替换前治具guid;
                       txt替换前治具rfid.Text = info.替换前治具rfid;
                   	txt替换前治具孔号.Value = info.替换前治具孔号;
                       txt替换后治具guid.Text = info.替换后治具guid;
                       txt替换后治具rfid.Text = info.替换后治具rfid;
                   	txt替换后治具孔号.Value = info.替换后治具孔号;
    
                } 
                #endregion
                //this.btnOK.Enabled = HasFunction("替换记录表/Edit");             
            }
            else
            {
         
                //this.btnOK.Enabled = HasFunction("替换记录表/Add");  
            }
            
            //tempInfo在对象存在则为指定对象，新建则是全新的对象，但有一些初始化的GUID用于附件上传
            //SetAttachInfo(tempInfo);
			
            //SetPermit(); //默认不使用字段权限
        }

        /// <summary>
        /// 设置控件字段的权限显示或者隐藏(默认不使用字段权限)
        /// </summary>
        private void SetPermit()
        {
            #region 设置控件和字段的对应关系
            //this.txt替换时间.Tag = "替换时间";
            //this.txt生产批次号.Tag = "生产批次号";
            //this.txt物料guid.Tag = "物料guid";
            //this.txt替换前治具guid.Tag = "替换前治具guid";
            //this.txt替换前治具rfid.Tag = "替换前治具rfid";
            //this.txt替换前治具孔号.Tag = "替换前治具孔号";
            //this.txt替换后治具guid.Tag = "替换后治具guid";
            //this.txt替换后治具rfid.Tag = "替换后治具rfid";
            //this.txt替换后治具孔号.Tag = "替换后治具孔号";
            #endregion
			
            //获取列表权限的列表
            //var permitDict = BLLFactory<FieldPermit>.Instance.GetColumnsPermit(typeof(替换记录表Info).FullName, LoginUserInfo.ID.ToInt32());
			//this.SetControlPermit(permitDict, this.layoutControl1);
		}

        /// <summary>
        /// 查看编辑附件信息
        /// </summary>
        //private void SetAttachInfo(替换记录表Info info)
        //{
        //    this.attachmentGUID.AttachmentGUID = info.AttachGUID;
        //    this.attachmentGUID.userId = LoginUserInfo.Name;

        //    string name = "替换记录表";
        //    if (!string.IsNullOrEmpty(name))
        //    {
        //        string dir = string.Format("{0}", name);
        //        this.attachmentGUID.Init(dir, info.替换记录id, LoginUserInfo.Name);
        //    }
        //}

        public override void ClearScreen()
        {
            this.tempInfo = new 替换记录表Info();
            base.ClearScreen();
        }

        /// <summary>
        /// 编辑或者保存状态下取值函数
        /// </summary>
        /// <param name="info"></param>
        private void SetInfo(替换记录表Info info)
        {
            info.替换时间 = txt替换时间.DateTime;
               info.生产批次号 = txt生产批次号.Text;
                info.物料guid = txt物料guid.Text;
                info.替换前治具guid = txt替换前治具guid.Text;
                info.替换前治具rfid = txt替换前治具rfid.Text;
                info.替换前治具孔号 = Convert.ToInt32(txt替换前治具孔号.Value);
                info.替换后治具guid = txt替换后治具guid.Text;
                info.替换后治具rfid = txt替换后治具rfid.Text;
                info.替换后治具孔号 = Convert.ToInt32(txt替换后治具孔号.Value);
            }
         
        /// <summary>
        /// 新增状态下的数据保存
        /// </summary>
        /// <returns></returns>
        public override bool SaveAddNew()
        {
            替换记录表Info info = tempInfo;//必须使用存在的局部变量，因为部分信息可能被附件使用
            SetInfo(info);

            try
            {
                #region 新增数据

                bool succeed = BLLFactory<替换记录表>.Instance.Insert(info);
                if (succeed)
                {
                    //可添加其他关联操作

                    return true;
                }
                #endregion
            }
            catch (Exception ex)
            {
                LogTextHelper.Error(ex);
                MessageDxUtil.ShowError(ex.Message);
            }
            return false;
        }                 

        /// <summary>
        /// 编辑状态下的数据保存
        /// </summary>
        /// <returns></returns>
        public override bool SaveUpdated()
        {

            替换记录表Info info = BLLFactory<替换记录表>.Instance.FindByID(ID);
            if (info != null)
            {
                SetInfo(info);

                try
                {
                    #region 更新数据
                    bool succeed = BLLFactory<替换记录表>.Instance.Update(info, info.替换记录id);
                    if (succeed)
                    {
                        //可添加其他关联操作
                       
                        return true;
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    LogTextHelper.Error(ex);
                    MessageDxUtil.ShowError(ex.Message);
                }
            }
           return false;
        }
    }
}
