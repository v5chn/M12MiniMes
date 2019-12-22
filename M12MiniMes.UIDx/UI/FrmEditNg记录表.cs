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
    /// Ng记录表
    /// </summary>	
    public partial class FrmEditNg记录表 : BaseEditForm
    {
    	/// <summary>
        /// 创建一个临时对象，方便在附件管理中获取存在的GUID
        /// </summary>
    	private Ng记录表Info tempInfo = new Ng记录表Info();
    	
        public FrmEditNg记录表()
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
                Ng记录表Info info = BLLFactory<Ng记录表>.Instance.FindByID(ID);
                if (info != null)
                {
                	tempInfo = info;//重新给临时对象赋值，使之指向存在的记录对象
                	
                	txtNg发生时间.SetDateTime(info.Ng发生时间);	
                      txt生产批次号.Text = info.生产批次号;
                       txt物料guid.Text = info.物料guid;
                       txt治具guid.Text = info.治具guid;
                       txt治具rfid.Text = info.治具rfid;
                   	txt治具孔号.Value = info.治具孔号;
                   	txt设备id.Value = info.设备id;
                       txt工位号.Text = info.工位号;
    
                } 
                #endregion
                //this.btnOK.Enabled = HasFunction("Ng记录表/Edit");             
            }
            else
            {
        
                //this.btnOK.Enabled = HasFunction("Ng记录表/Add");  
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
            //this.txtNg发生时间.Tag = "Ng发生时间";
            //this.txt生产批次号.Tag = "生产批次号";
            //this.txt物料guid.Tag = "物料guid";
            //this.txt治具guid.Tag = "治具guid";
            //this.txt治具rfid.Tag = "治具rfid";
            //this.txt治具孔号.Tag = "治具孔号";
            //this.txt设备id.Tag = "设备id";
            //this.txt工位号.Tag = "工位号";
            #endregion
			
            //获取列表权限的列表
            //var permitDict = BLLFactory<FieldPermit>.Instance.GetColumnsPermit(typeof(Ng记录表Info).FullName, LoginUserInfo.ID.ToInt32());
			//this.SetControlPermit(permitDict, this.layoutControl1);
		}

        /// <summary>
        /// 查看编辑附件信息
        /// </summary>
        //private void SetAttachInfo(Ng记录表Info info)
        //{
        //    this.attachmentGUID.AttachmentGUID = info.AttachGUID;
        //    this.attachmentGUID.userId = LoginUserInfo.Name;

        //    string name = "Ng记录表";
        //    if (!string.IsNullOrEmpty(name))
        //    {
        //        string dir = string.Format("{0}", name);
        //        this.attachmentGUID.Init(dir, info.Ng记录id, LoginUserInfo.Name);
        //    }
        //}

        public override void ClearScreen()
        {
            this.tempInfo = new Ng记录表Info();
            base.ClearScreen();
        }

        /// <summary>
        /// 编辑或者保存状态下取值函数
        /// </summary>
        /// <param name="info"></param>
        private void SetInfo(Ng记录表Info info)
        {
            info.Ng发生时间 = txtNg发生时间.DateTime;
               info.生产批次号 = txt生产批次号.Text;
                info.物料guid = txt物料guid.Text;
                info.治具guid = txt治具guid.Text;
                info.治具rfid = txt治具rfid.Text;
                info.治具孔号 = Convert.ToInt32(txt治具孔号.Value);
                info.设备id = Convert.ToInt32(txt设备id.Value);
                info.工位号 = txt工位号.Text;
            }
         
        /// <summary>
        /// 新增状态下的数据保存
        /// </summary>
        /// <returns></returns>
        public override bool SaveAddNew()
        {
            Ng记录表Info info = tempInfo;//必须使用存在的局部变量，因为部分信息可能被附件使用
            SetInfo(info);

            try
            {
                #region 新增数据

                bool succeed = BLLFactory<Ng记录表>.Instance.Insert(info);
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

            Ng记录表Info info = BLLFactory<Ng记录表>.Instance.FindByID(ID);
            if (info != null)
            {
                SetInfo(info);

                try
                {
                    #region 更新数据
                    bool succeed = BLLFactory<Ng记录表>.Instance.Update(info, info.Ng记录id);
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
