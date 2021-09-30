// Generated on 29-Sep-2021 05:06:46 by gencs v0.0.0.0
// 
// The contents of this file are auto-generated. Only add modifications to the end of this file.
// Any modifications will be lost when the file is re-generated.
// 
using System;
using System.Text;
using Synergex.xfnlnet;
namespace SynergyClient
{
/// <summary>
/// Structural Interface Class SynergyClient
/// </summary>
	[XFAttr(size=118)]
	[Serializable]
	public partial class Customer : IStructWire
	{
		/// <summary>
		/// Attributes for fields
		/// </summary>
		public readonly static XFAttr[] fieldAttributes = new XFAttr[7];
		static Customer()
		{
			fieldAttributes[0]= new XFAttr(XFAttr.xftype.INTEGER,4);
			fieldAttributes[1]= new XFAttr(XFAttr.xftype.ALPHA,40);
			fieldAttributes[2]= new XFAttr(XFAttr.xftype.DATE,XFAttr.xftype.DATETIME,XFAttr.xfformat.YYYYMMDD,8);
			fieldAttributes[3]= new XFAttr(XFAttr.xftype.DATE,XFAttr.xftype.DATETIME,XFAttr.xfformat.YYYYMMDD,8);
			fieldAttributes[4]= new XFAttr(XFAttr.xftype.ALPHA,1);
			fieldAttributes[5]= new XFAttr(XFAttr.xftype.ALPHA,20);
			fieldAttributes[6]= new XFAttr(XFAttr.xftype.ALPHA,37);
		}
		private int f_Customer_id=0;
		 
		/// <summary>
		/// Customer ID
		/// </summary>
		public int Customer_id
		{
			get{ return f_Customer_id;}
			set { 
			    if(f_Customer_id != value) 
			    { 
			       m_changed = true; 
			    } 
			    f_Customer_id = value;
			} 
		}
		 
		private string f_Name="";
		 
		/// <summary>
		/// Customer name
		/// </summary>
		public string Name
		{
			get{ return f_Name;}
			set { 
			      if((f_Name == null) && (value != null)) 
			      { 
			         m_changed = true; 
			      } 
			      else
			      { 
			        if(!f_Name.Equals(value)) 
			        { 
			           m_changed = true; 
			        } 
			      } 
			      f_Name = value;
			} 
		}
		 
		private DateTime f_Date_created=new DateTime();
		 
		/// <summary>
		/// Date customer was created
		/// </summary>
		public DateTime Date_created
		{
			get{ return f_Date_created;}
			set { 
			    if(f_Date_created != value) 
			    { 
			       m_changed = true; 
			    } 
			    f_Date_created = value;
			} 
		}
		 
		private DateTime f_Date_modified=new DateTime();
		 
		/// <summary>
		/// Last modification date
		/// </summary>
		public DateTime Date_modified
		{
			get{ return f_Date_modified;}
			set { 
			    if(f_Date_modified != value) 
			    { 
			       m_changed = true; 
			    } 
			    f_Date_modified = value;
			} 
		}
		 
		private string f_Status="";
		 
		/// <summary>
		/// Company status
		/// </summary>
		public string Status
		{
			get{ return f_Status;}
			set { 
			      if((f_Status == null) && (value != null)) 
			      { 
			         m_changed = true; 
			      } 
			      else
			      { 
			        if(!f_Status.Equals(value)) 
			        { 
			           m_changed = true; 
			        } 
			      } 
			      f_Status = value;
			} 
		}
		 
		private string f_Replication_key="";
		 
		/// <summary>
		/// SQL Replication Timestamp
		/// </summary>
		public string Replication_key
		{
			get{ return f_Replication_key;}
			set { 
			      if((f_Replication_key == null) && (value != null)) 
			      { 
			         m_changed = true; 
			      } 
			      else
			      { 
			        if(!f_Replication_key.Equals(value)) 
			        { 
			           m_changed = true; 
			        } 
			      } 
			      f_Replication_key = value;
			} 
		}
		 
		private string f_Noname_001="";
		 
		/// <summary>
		/// Filler record
		/// </summary>
		public string Noname_001
		{
			get{ return f_Noname_001;}
			set { 
			      if((f_Noname_001 == null) && (value != null)) 
			      { 
			         m_changed = true; 
			      } 
			      else
			      { 
			        if(!f_Noname_001.Equals(value)) 
			        { 
			           m_changed = true; 
			        } 
			      } 
			      f_Noname_001 = value;
			} 
		}
		 
		/// <summary>
		/// structure clone
		/// </summary>
		public Customer Clone()
		{
			Customer tmp = new Customer();
			tmp.f_Customer_id = this.f_Customer_id;
			tmp.f_Name = this.f_Name;
			tmp.f_Date_created = this.f_Date_created;
			tmp.f_Date_modified = this.f_Date_modified;
			tmp.f_Status = this.f_Status;
			tmp.f_Replication_key = this.f_Replication_key;
			tmp.f_Noname_001 = this.f_Noname_001;
			return tmp;
		}
		/// <summary>
		/// structure equals
		/// </summary>
		public bool Equals(Customer str)
		{
			bool eq = true;
			if (this.Customer_id != str.Customer_id)
			{
				eq = false;
				return eq;
			}
			if (!this.Name.Equals(str.Name))
			{
				eq = false;
				return eq;
			}
			if (this.Date_created != str.Date_created)
			{
				eq = false;
				return eq;
			}
			if (this.Date_modified != str.Date_modified)
			{
				eq = false;
				return eq;
			}
			if (!this.Status.Equals(str.Status))
			{
				eq = false;
				return eq;
			}
			if (!this.Replication_key.Equals(str.Replication_key))
			{
				eq = false;
				return eq;
			}
			if (!this.Noname_001.Equals(str.Noname_001))
			{
				eq = false;
				return eq;
			}
			return eq;
		}
		/// <summary>
		/// Constructor
		/// </summary>
		public Customer() {
		}
		/// <summary>
		/// serialize structure
		/// </summary>
		public string structToWire()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("ST[7]118%");
			StringBuilder body = new StringBuilder();
			body.Append(XFProtocol.fieldToWire(f_Customer_id,fieldAttributes[0]));
			body.Append(XFProtocol.fieldToWire(f_Name,fieldAttributes[1]));
			body.Append(XFProtocol.fieldToWire(f_Date_created,fieldAttributes[2]));
			body.Append(XFProtocol.fieldToWire(f_Date_modified,fieldAttributes[3]));
			body.Append(XFProtocol.fieldToWire(f_Status,fieldAttributes[4]));
			body.Append(XFProtocol.fieldToWire(f_Replication_key,fieldAttributes[5]));
			body.Append(XFProtocol.fieldToWire(f_Noname_001,fieldAttributes[6]));
			body.Append("^");
			sb.Append(body.Length+"#"+body.ToString()+";");
			return sb.ToString();
		}
 
		/// <summary>
		/// deserialize structure
		/// </summary>
		public void wireToStruct(SynMessage reply)
		{
			f_Customer_id = XFProtocol.wireToint(reply);
			f_Name = XFProtocol.wireTostring(reply);
			f_Date_created = XFProtocol.wireToDateTime(reply,fieldAttributes[2]);
			f_Date_modified = XFProtocol.wireToDateTime(reply,fieldAttributes[3]);
			f_Status = XFProtocol.wireTostring(reply);
			f_Replication_key = XFProtocol.wireTostring(reply);
			f_Noname_001 = XFProtocol.wireTostring(reply);
		}
 
		private bool m_changed = false;
 
		/// <summary>
		/// Structure Changed 
		/// </summary>
		/// <returns>true if structure has been changed</returns>
		public bool Changed
		{
		    get{ return m_changed;}
		}
 
	}
}
