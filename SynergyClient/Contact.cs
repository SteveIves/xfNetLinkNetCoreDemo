// Generated on 08-Oct-2021 03:12:52 by gencs v0.0.0.0
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
	[XFAttr(size=691)]
	[Serializable]
	public partial class Contact : IStructWire
	{
		/// <summary>
		/// Attributes for fields
		/// </summary>
		public readonly static XFAttr[] fieldAttributes = new XFAttr[24];
		static Contact()
		{
			fieldAttributes[0]= new XFAttr(XFAttr.xftype.INTEGER,4);
			fieldAttributes[1]= new XFAttr(XFAttr.xftype.INTEGER,4);
			fieldAttributes[2]= new XFAttr(XFAttr.xftype.INTEGER,4);
			fieldAttributes[3]= new XFAttr(XFAttr.xftype.ALPHA,5);
			fieldAttributes[4]= new XFAttr(XFAttr.xftype.ALPHA,30);
			fieldAttributes[5]= new XFAttr(XFAttr.xftype.ALPHA,30);
			fieldAttributes[6]= new XFAttr(XFAttr.xftype.ALPHA,60);
			fieldAttributes[7]= new XFAttr(XFAttr.xftype.ALPHA,25);
			fieldAttributes[8]= new XFAttr(XFAttr.xftype.ALPHA,15);
			fieldAttributes[9]= new XFAttr(XFAttr.xftype.DECIMAL,12);
			fieldAttributes[10]= new XFAttr(XFAttr.xftype.DECIMAL,6);
			fieldAttributes[11]= new XFAttr(XFAttr.xftype.DECIMAL,12);
			fieldAttributes[12]= new XFAttr(XFAttr.xftype.DECIMAL,12);
			fieldAttributes[13]= new XFAttr(XFAttr.xftype.DECIMAL,12);
			fieldAttributes[14]= new XFAttr(XFAttr.xftype.ALPHA,50);
			fieldAttributes[15]= new XFAttr(XFAttr.xftype.ALPHA,50);
			fieldAttributes[16]= new XFAttr(XFAttr.xftype.ALPHA,255);
			fieldAttributes[17]= new XFAttr(XFAttr.xftype.DECIMAL,XFAttr.xftype.BOOLEAN,1);
			fieldAttributes[18]= new XFAttr(XFAttr.xftype.DECIMAL,XFAttr.xftype.BOOLEAN,1);
			fieldAttributes[19]= new XFAttr(XFAttr.xftype.DECIMAL,XFAttr.xftype.BOOLEAN,1);
			fieldAttributes[20]= new XFAttr(XFAttr.xftype.DECIMAL,XFAttr.xftype.BOOLEAN,1);
			fieldAttributes[21]= new XFAttr(XFAttr.xftype.DECIMAL,XFAttr.xftype.BOOLEAN,1);
			fieldAttributes[22]= new XFAttr(XFAttr.xftype.ALPHA,20);
			fieldAttributes[23]= new XFAttr(XFAttr.xftype.ALPHA,80);
		}
		private int f_Contact_id=0;
		 
		/// <summary>
		/// Contact ID
		/// </summary>
		public int Contact_id
		{
			get{ return f_Contact_id;}
			set { 
			    if(f_Contact_id != value) 
			    { 
			       m_changed = true; 
			    } 
			    f_Contact_id = value;
			} 
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
		 
		private int f_Address_id=0;
		 
		/// <summary>
		/// Address ID
		/// </summary>
		public int Address_id
		{
			get{ return f_Address_id;}
			set { 
			    if(f_Address_id != value) 
			    { 
			       m_changed = true; 
			    } 
			    f_Address_id = value;
			} 
		}
		 
		private string f_Salutation="";
		 
		/// <summary>
		/// Contact salutation
		/// </summary>
		public string Salutation
		{
			get{ return f_Salutation;}
			set { 
			      if((f_Salutation == null) && (value != null)) 
			      { 
			         m_changed = true; 
			      } 
			      else
			      { 
			        if(!f_Salutation.Equals(value)) 
			        { 
			           m_changed = true; 
			        } 
			      } 
			      f_Salutation = value;
			} 
		}
		 
		private string f_First_name="";
		 
		/// <summary>
		/// Contact first name
		/// </summary>
		public string First_name
		{
			get{ return f_First_name;}
			set { 
			      if((f_First_name == null) && (value != null)) 
			      { 
			         m_changed = true; 
			      } 
			      else
			      { 
			        if(!f_First_name.Equals(value)) 
			        { 
			           m_changed = true; 
			        } 
			      } 
			      f_First_name = value;
			} 
		}
		 
		private string f_Last_name="";
		 
		/// <summary>
		/// Contact last name
		/// </summary>
		public string Last_name
		{
			get{ return f_Last_name;}
			set { 
			      if((f_Last_name == null) && (value != null)) 
			      { 
			         m_changed = true; 
			      } 
			      else
			      { 
			        if(!f_Last_name.Equals(value)) 
			        { 
			           m_changed = true; 
			        } 
			      } 
			      f_Last_name = value;
			} 
		}
		 
		private string f_Friendly_name="";
		 
		/// <summary>
		/// Contact friendly/printable name
		/// </summary>
		public string Friendly_name
		{
			get{ return f_Friendly_name;}
			set { 
			      if((f_Friendly_name == null) && (value != null)) 
			      { 
			         m_changed = true; 
			      } 
			      else
			      { 
			        if(!f_Friendly_name.Equals(value)) 
			        { 
			           m_changed = true; 
			        } 
			      } 
			      f_Friendly_name = value;
			} 
		}
		 
		private string f_Title="";
		 
		/// <summary>
		/// Contact title
		/// </summary>
		public string Title
		{
			get{ return f_Title;}
			set { 
			      if((f_Title == null) && (value != null)) 
			      { 
			         m_changed = true; 
			      } 
			      else
			      { 
			        if(!f_Title.Equals(value)) 
			        { 
			           m_changed = true; 
			        } 
			      } 
			      f_Title = value;
			} 
		}
		 
		private string f_Department="";
		 
		/// <summary>
		/// Department name
		/// </summary>
		public string Department
		{
			get{ return f_Department;}
			set { 
			      if((f_Department == null) && (value != null)) 
			      { 
			         m_changed = true; 
			      } 
			      else
			      { 
			        if(!f_Department.Equals(value)) 
			        { 
			           m_changed = true; 
			        } 
			      } 
			      f_Department = value;
			} 
		}
		 
		private long f_Work_phone=0;
		 
		/// <summary>
		/// Work phone
		/// </summary>
		public long Work_phone
		{
			get{ return f_Work_phone;}
			set { 
			    if(f_Work_phone != value) 
			    { 
			       m_changed = true; 
			    } 
			    f_Work_phone = value;
			} 
		}
		 
		private int f_Work_extension=0;
		 
		/// <summary>
		/// Work phone extension
		/// </summary>
		public int Work_extension
		{
			get{ return f_Work_extension;}
			set { 
			    if(f_Work_extension != value) 
			    { 
			       m_changed = true; 
			    } 
			    f_Work_extension = value;
			} 
		}
		 
		private long f_Mobile_phone=0;
		 
		/// <summary>
		/// Mobile phone
		/// </summary>
		public long Mobile_phone
		{
			get{ return f_Mobile_phone;}
			set { 
			    if(f_Mobile_phone != value) 
			    { 
			       m_changed = true; 
			    } 
			    f_Mobile_phone = value;
			} 
		}
		 
		private long f_Home_phone=0;
		 
		/// <summary>
		/// Home phone
		/// </summary>
		public long Home_phone
		{
			get{ return f_Home_phone;}
			set { 
			    if(f_Home_phone != value) 
			    { 
			       m_changed = true; 
			    } 
			    f_Home_phone = value;
			} 
		}
		 
		private long f_Fax=0;
		 
		/// <summary>
		/// Fax number
		/// </summary>
		public long Fax
		{
			get{ return f_Fax;}
			set { 
			    if(f_Fax != value) 
			    { 
			       m_changed = true; 
			    } 
			    f_Fax = value;
			} 
		}
		 
		private string f_Web_site="";
		 
		/// <summary>
		/// Web site
		/// </summary>
		public string Web_site
		{
			get{ return f_Web_site;}
			set { 
			      if((f_Web_site == null) && (value != null)) 
			      { 
			         m_changed = true; 
			      } 
			      else
			      { 
			        if(!f_Web_site.Equals(value)) 
			        { 
			           m_changed = true; 
			        } 
			      } 
			      f_Web_site = value;
			} 
		}
		 
		private string f_Email="";
		 
		/// <summary>
		/// Email address
		/// </summary>
		public string Email
		{
			get{ return f_Email;}
			set { 
			      if((f_Email == null) && (value != null)) 
			      { 
			         m_changed = true; 
			      } 
			      else
			      { 
			        if(!f_Email.Equals(value)) 
			        { 
			           m_changed = true; 
			        } 
			      } 
			      f_Email = value;
			} 
		}
		 
		private string f_Picture_file="";
		 
		/// <summary>
		/// Path to contact image file
		/// </summary>
		public string Picture_file
		{
			get{ return f_Picture_file;}
			set { 
			      if((f_Picture_file == null) && (value != null)) 
			      { 
			         m_changed = true; 
			      } 
			      else
			      { 
			        if(!f_Picture_file.Equals(value)) 
			        { 
			           m_changed = true; 
			        } 
			      } 
			      f_Picture_file = value;
			} 
		}
		 
		private bool f_Management_contact=new bool();
		 
		/// <summary>
		/// Contact has a management role
		/// </summary>
		public bool Management_contact
		{
			get{ return f_Management_contact;}
			set { 
			    if(f_Management_contact != value) 
			    { 
			       m_changed = true; 
			    } 
			    f_Management_contact = value;
			} 
		}
		 
		private bool f_Technical_contact=new bool();
		 
		/// <summary>
		/// Contact has technical role
		/// </summary>
		public bool Technical_contact
		{
			get{ return f_Technical_contact;}
			set { 
			    if(f_Technical_contact != value) 
			    { 
			       m_changed = true; 
			    } 
			    f_Technical_contact = value;
			} 
		}
		 
		private bool f_Sales_contact=new bool();
		 
		/// <summary>
		/// Contact has a role in sales
		/// </summary>
		public bool Sales_contact
		{
			get{ return f_Sales_contact;}
			set { 
			    if(f_Sales_contact != value) 
			    { 
			       m_changed = true; 
			    } 
			    f_Sales_contact = value;
			} 
		}
		 
		private bool f_Billing_contact=new bool();
		 
		/// <summary>
		/// Contact for billing purposes
		/// </summary>
		public bool Billing_contact
		{
			get{ return f_Billing_contact;}
			set { 
			    if(f_Billing_contact != value) 
			    { 
			       m_changed = true; 
			    } 
			    f_Billing_contact = value;
			} 
		}
		 
		private bool f_General_contact=new bool();
		 
		/// <summary>
		/// This is a general contact
		/// </summary>
		public bool General_contact
		{
			get{ return f_General_contact;}
			set { 
			    if(f_General_contact != value) 
			    { 
			       m_changed = true; 
			    } 
			    f_General_contact = value;
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
		/// Filler
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
		public Contact Clone()
		{
			Contact tmp = new Contact();
			tmp.f_Contact_id = this.f_Contact_id;
			tmp.f_Customer_id = this.f_Customer_id;
			tmp.f_Address_id = this.f_Address_id;
			tmp.f_Salutation = this.f_Salutation;
			tmp.f_First_name = this.f_First_name;
			tmp.f_Last_name = this.f_Last_name;
			tmp.f_Friendly_name = this.f_Friendly_name;
			tmp.f_Title = this.f_Title;
			tmp.f_Department = this.f_Department;
			tmp.f_Work_phone = this.f_Work_phone;
			tmp.f_Work_extension = this.f_Work_extension;
			tmp.f_Mobile_phone = this.f_Mobile_phone;
			tmp.f_Home_phone = this.f_Home_phone;
			tmp.f_Fax = this.f_Fax;
			tmp.f_Web_site = this.f_Web_site;
			tmp.f_Email = this.f_Email;
			tmp.f_Picture_file = this.f_Picture_file;
			tmp.f_Management_contact = this.f_Management_contact;
			tmp.f_Technical_contact = this.f_Technical_contact;
			tmp.f_Sales_contact = this.f_Sales_contact;
			tmp.f_Billing_contact = this.f_Billing_contact;
			tmp.f_General_contact = this.f_General_contact;
			tmp.f_Replication_key = this.f_Replication_key;
			tmp.f_Noname_001 = this.f_Noname_001;
			return tmp;
		}
		/// <summary>
		/// structure equals
		/// </summary>
		public bool Equals(Contact str)
		{
			bool eq = true;
			if (this.Contact_id != str.Contact_id)
			{
				eq = false;
				return eq;
			}
			if (this.Customer_id != str.Customer_id)
			{
				eq = false;
				return eq;
			}
			if (this.Address_id != str.Address_id)
			{
				eq = false;
				return eq;
			}
			if (!this.Salutation.Equals(str.Salutation))
			{
				eq = false;
				return eq;
			}
			if (!this.First_name.Equals(str.First_name))
			{
				eq = false;
				return eq;
			}
			if (!this.Last_name.Equals(str.Last_name))
			{
				eq = false;
				return eq;
			}
			if (!this.Friendly_name.Equals(str.Friendly_name))
			{
				eq = false;
				return eq;
			}
			if (!this.Title.Equals(str.Title))
			{
				eq = false;
				return eq;
			}
			if (!this.Department.Equals(str.Department))
			{
				eq = false;
				return eq;
			}
			if (this.Work_phone != str.Work_phone)
			{
				eq = false;
				return eq;
			}
			if (this.Work_extension != str.Work_extension)
			{
				eq = false;
				return eq;
			}
			if (this.Mobile_phone != str.Mobile_phone)
			{
				eq = false;
				return eq;
			}
			if (this.Home_phone != str.Home_phone)
			{
				eq = false;
				return eq;
			}
			if (this.Fax != str.Fax)
			{
				eq = false;
				return eq;
			}
			if (!this.Web_site.Equals(str.Web_site))
			{
				eq = false;
				return eq;
			}
			if (!this.Email.Equals(str.Email))
			{
				eq = false;
				return eq;
			}
			if (!this.Picture_file.Equals(str.Picture_file))
			{
				eq = false;
				return eq;
			}
			if (this.Management_contact != str.Management_contact)
			{
				eq = false;
				return eq;
			}
			if (this.Technical_contact != str.Technical_contact)
			{
				eq = false;
				return eq;
			}
			if (this.Sales_contact != str.Sales_contact)
			{
				eq = false;
				return eq;
			}
			if (this.Billing_contact != str.Billing_contact)
			{
				eq = false;
				return eq;
			}
			if (this.General_contact != str.General_contact)
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
		public Contact() {
		}
		/// <summary>
		/// serialize structure
		/// </summary>
		public string structToWire()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("ST[24]691%");
			StringBuilder body = new StringBuilder();
			body.Append(XFProtocol.fieldToWire(f_Contact_id,fieldAttributes[0]));
			body.Append(XFProtocol.fieldToWire(f_Customer_id,fieldAttributes[1]));
			body.Append(XFProtocol.fieldToWire(f_Address_id,fieldAttributes[2]));
			body.Append(XFProtocol.fieldToWire(f_Salutation,fieldAttributes[3]));
			body.Append(XFProtocol.fieldToWire(f_First_name,fieldAttributes[4]));
			body.Append(XFProtocol.fieldToWire(f_Last_name,fieldAttributes[5]));
			body.Append(XFProtocol.fieldToWire(f_Friendly_name,fieldAttributes[6]));
			body.Append(XFProtocol.fieldToWire(f_Title,fieldAttributes[7]));
			body.Append(XFProtocol.fieldToWire(f_Department,fieldAttributes[8]));
			body.Append(XFProtocol.fieldToWire(f_Work_phone,fieldAttributes[9]));
			body.Append(XFProtocol.fieldToWire(f_Work_extension,fieldAttributes[10]));
			body.Append(XFProtocol.fieldToWire(f_Mobile_phone,fieldAttributes[11]));
			body.Append(XFProtocol.fieldToWire(f_Home_phone,fieldAttributes[12]));
			body.Append(XFProtocol.fieldToWire(f_Fax,fieldAttributes[13]));
			body.Append(XFProtocol.fieldToWire(f_Web_site,fieldAttributes[14]));
			body.Append(XFProtocol.fieldToWire(f_Email,fieldAttributes[15]));
			body.Append(XFProtocol.fieldToWire(f_Picture_file,fieldAttributes[16]));
			body.Append(XFProtocol.fieldToWire(f_Management_contact,fieldAttributes[17]));
			body.Append(XFProtocol.fieldToWire(f_Technical_contact,fieldAttributes[18]));
			body.Append(XFProtocol.fieldToWire(f_Sales_contact,fieldAttributes[19]));
			body.Append(XFProtocol.fieldToWire(f_Billing_contact,fieldAttributes[20]));
			body.Append(XFProtocol.fieldToWire(f_General_contact,fieldAttributes[21]));
			body.Append(XFProtocol.fieldToWire(f_Replication_key,fieldAttributes[22]));
			body.Append(XFProtocol.fieldToWire(f_Noname_001,fieldAttributes[23]));
			body.Append("^");
			sb.Append(body.Length+"#"+body.ToString()+";");
			return sb.ToString();
		}
 
		/// <summary>
		/// deserialize structure
		/// </summary>
		public void wireToStruct(SynMessage reply)
		{
			f_Contact_id = XFProtocol.wireToint(reply);
			f_Customer_id = XFProtocol.wireToint(reply);
			f_Address_id = XFProtocol.wireToint(reply);
			f_Salutation = XFProtocol.wireTostring(reply);
			f_First_name = XFProtocol.wireTostring(reply);
			f_Last_name = XFProtocol.wireTostring(reply);
			f_Friendly_name = XFProtocol.wireTostring(reply);
			f_Title = XFProtocol.wireTostring(reply);
			f_Department = XFProtocol.wireTostring(reply);
			f_Work_phone = XFProtocol.wireTolong(reply);
			f_Work_extension = XFProtocol.wireToint(reply);
			f_Mobile_phone = XFProtocol.wireTolong(reply);
			f_Home_phone = XFProtocol.wireTolong(reply);
			f_Fax = XFProtocol.wireTolong(reply);
			f_Web_site = XFProtocol.wireTostring(reply);
			f_Email = XFProtocol.wireTostring(reply);
			f_Picture_file = XFProtocol.wireTostring(reply);
			f_Management_contact = XFProtocol.wireTobool(reply);
			f_Technical_contact = XFProtocol.wireTobool(reply);
			f_Sales_contact = XFProtocol.wireTobool(reply);
			f_Billing_contact = XFProtocol.wireTobool(reply);
			f_General_contact = XFProtocol.wireTobool(reply);
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
