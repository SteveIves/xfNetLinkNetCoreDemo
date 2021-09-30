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
	[XFAttr(size=250)]
	[Serializable]
	public partial class Address : IStructWire
	{
		/// <summary>
		/// Attributes for fields
		/// </summary>
		public readonly static XFAttr[] fieldAttributes = new XFAttr[16];
		static Address()
		{
			fieldAttributes[0]= new XFAttr(XFAttr.xftype.INTEGER,4);
			fieldAttributes[1]= new XFAttr(XFAttr.xftype.INTEGER,4);
			fieldAttributes[2]= new XFAttr(XFAttr.xftype.ENUM,4);
			fieldAttributes[3]= new XFAttr(XFAttr.xftype.ALPHA,50);
			fieldAttributes[4]= new XFAttr(XFAttr.xftype.ALPHA,50);
			fieldAttributes[5]= new XFAttr(XFAttr.xftype.ALPHA,50);
			fieldAttributes[6]= new XFAttr(XFAttr.xftype.ALPHA,30);
			fieldAttributes[7]= new XFAttr(XFAttr.xftype.ALPHA,10);
			fieldAttributes[8]= new XFAttr(XFAttr.xftype.ALPHA,2);
			fieldAttributes[9]= new XFAttr(XFAttr.xftype.ALPHA,2);
			fieldAttributes[10]= new XFAttr(XFAttr.xftype.INTEGER,XFAttr.xftype.BOOLEAN,4);
			fieldAttributes[11]= new XFAttr(XFAttr.xftype.INTEGER,XFAttr.xftype.BOOLEAN,4);
			fieldAttributes[12]= new XFAttr(XFAttr.xftype.INTEGER,XFAttr.xftype.BOOLEAN,4);
			fieldAttributes[13]= new XFAttr(XFAttr.xftype.INTEGER,XFAttr.xftype.BOOLEAN,4);
			fieldAttributes[14]= new XFAttr(XFAttr.xftype.DATE,XFAttr.xftype.DATETIME,XFAttr.xfformat.YYYYMMDD,8);
			fieldAttributes[15]= new XFAttr(XFAttr.xftype.ALPHA,20);
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
		 
		private Address_type f_Address_type=new Address_type();
		 
		/// <summary>
		/// Type of address
		/// </summary>
		public Address_type Address_type
		{
			get{ return f_Address_type;}
			set { 
			    if(f_Address_type != value) 
			    { 
			       m_changed = true; 
			    } 
			    f_Address_type = value;
			} 
		}
		 
		private string f_Address1="";
		 
		/// <summary>
		/// Address Line 1 - Number, Building
		/// </summary>
		public string Address1
		{
			get{ return f_Address1;}
			set { 
			      if((f_Address1 == null) && (value != null)) 
			      { 
			         m_changed = true; 
			      } 
			      else
			      { 
			        if(!f_Address1.Equals(value)) 
			        { 
			           m_changed = true; 
			        } 
			      } 
			      f_Address1 = value;
			} 
		}
		 
		private string f_Address2="";
		 
		/// <summary>
		/// Address Line 2 - Number, street
		/// </summary>
		public string Address2
		{
			get{ return f_Address2;}
			set { 
			      if((f_Address2 == null) && (value != null)) 
			      { 
			         m_changed = true; 
			      } 
			      else
			      { 
			        if(!f_Address2.Equals(value)) 
			        { 
			           m_changed = true; 
			        } 
			      } 
			      f_Address2 = value;
			} 
		}
		 
		private string f_Address3="";
		 
		/// <summary>
		/// Address Line 3 - Area, locality
		/// </summary>
		public string Address3
		{
			get{ return f_Address3;}
			set { 
			      if((f_Address3 == null) && (value != null)) 
			      { 
			         m_changed = true; 
			      } 
			      else
			      { 
			        if(!f_Address3.Equals(value)) 
			        { 
			           m_changed = true; 
			        } 
			      } 
			      f_Address3 = value;
			} 
		}
		 
		private string f_City="";
		 
		/// <summary>
		/// City
		/// </summary>
		public string City
		{
			get{ return f_City;}
			set { 
			      if((f_City == null) && (value != null)) 
			      { 
			         m_changed = true; 
			      } 
			      else
			      { 
			        if(!f_City.Equals(value)) 
			        { 
			           m_changed = true; 
			        } 
			      } 
			      f_City = value;
			} 
		}
		 
		private string f_Postal_code="";
		 
		/// <summary>
		/// Zip or Postal code
		/// </summary>
		public string Postal_code
		{
			get{ return f_Postal_code;}
			set { 
			      if((f_Postal_code == null) && (value != null)) 
			      { 
			         m_changed = true; 
			      } 
			      else
			      { 
			        if(!f_Postal_code.Equals(value)) 
			        { 
			           m_changed = true; 
			        } 
			      } 
			      f_Postal_code = value;
			} 
		}
		 
		private string f_State="";
		 
		/// <summary>
		/// State, Province or Country
		/// </summary>
		public string State
		{
			get{ return f_State;}
			set { 
			      if((f_State == null) && (value != null)) 
			      { 
			         m_changed = true; 
			      } 
			      else
			      { 
			        if(!f_State.Equals(value)) 
			        { 
			           m_changed = true; 
			        } 
			      } 
			      f_State = value;
			} 
		}
		 
		private string f_Country="";
		 
		/// <summary>
		/// Country
		/// </summary>
		public string Country
		{
			get{ return f_Country;}
			set { 
			      if((f_Country == null) && (value != null)) 
			      { 
			         m_changed = true; 
			      } 
			      else
			      { 
			        if(!f_Country.Equals(value)) 
			        { 
			           m_changed = true; 
			        } 
			      } 
			      f_Country = value;
			} 
		}
		 
		private bool f_Mailing_address=new bool();
		 
		/// <summary>
		/// This is a mailing address
		/// </summary>
		public bool Mailing_address
		{
			get{ return f_Mailing_address;}
			set { 
			    if(f_Mailing_address != value) 
			    { 
			       m_changed = true; 
			    } 
			    f_Mailing_address = value;
			} 
		}
		 
		private bool f_Billing_address=new bool();
		 
		/// <summary>
		/// This is a billing address
		/// </summary>
		public bool Billing_address
		{
			get{ return f_Billing_address;}
			set { 
			    if(f_Billing_address != value) 
			    { 
			       m_changed = true; 
			    } 
			    f_Billing_address = value;
			} 
		}
		 
		private bool f_Main_address=new bool();
		 
		/// <summary>
		/// This is the main office address
		/// </summary>
		public bool Main_address
		{
			get{ return f_Main_address;}
			set { 
			    if(f_Main_address != value) 
			    { 
			       m_changed = true; 
			    } 
			    f_Main_address = value;
			} 
		}
		 
		private bool f_Satellite_office=new bool();
		 
		/// <summary>
		/// This is a satellite office address
		/// </summary>
		public bool Satellite_office
		{
			get{ return f_Satellite_office;}
			set { 
			    if(f_Satellite_office != value) 
			    { 
			       m_changed = true; 
			    } 
			    f_Satellite_office = value;
			} 
		}
		 
		private DateTime f_Active_date=new DateTime();
		 
		/// <summary>
		/// Date address became active
		/// </summary>
		public DateTime Active_date
		{
			get{ return f_Active_date;}
			set { 
			    if(f_Active_date != value) 
			    { 
			       m_changed = true; 
			    } 
			    f_Active_date = value;
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
		 
		/// <summary>
		/// structure clone
		/// </summary>
		public Address Clone()
		{
			Address tmp = new Address();
			tmp.f_Address_id = this.f_Address_id;
			tmp.f_Customer_id = this.f_Customer_id;
			tmp.f_Address_type = this.f_Address_type;
			tmp.f_Address1 = this.f_Address1;
			tmp.f_Address2 = this.f_Address2;
			tmp.f_Address3 = this.f_Address3;
			tmp.f_City = this.f_City;
			tmp.f_Postal_code = this.f_Postal_code;
			tmp.f_State = this.f_State;
			tmp.f_Country = this.f_Country;
			tmp.f_Mailing_address = this.f_Mailing_address;
			tmp.f_Billing_address = this.f_Billing_address;
			tmp.f_Main_address = this.f_Main_address;
			tmp.f_Satellite_office = this.f_Satellite_office;
			tmp.f_Active_date = this.f_Active_date;
			tmp.f_Replication_key = this.f_Replication_key;
			return tmp;
		}
		/// <summary>
		/// structure equals
		/// </summary>
		public bool Equals(Address str)
		{
			bool eq = true;
			if (this.Address_id != str.Address_id)
			{
				eq = false;
				return eq;
			}
			if (this.Customer_id != str.Customer_id)
			{
				eq = false;
				return eq;
			}
			if (this.Address_type != str.Address_type)
			{
				eq = false;
				return eq;
			}
			if (!this.Address1.Equals(str.Address1))
			{
				eq = false;
				return eq;
			}
			if (!this.Address2.Equals(str.Address2))
			{
				eq = false;
				return eq;
			}
			if (!this.Address3.Equals(str.Address3))
			{
				eq = false;
				return eq;
			}
			if (!this.City.Equals(str.City))
			{
				eq = false;
				return eq;
			}
			if (!this.Postal_code.Equals(str.Postal_code))
			{
				eq = false;
				return eq;
			}
			if (!this.State.Equals(str.State))
			{
				eq = false;
				return eq;
			}
			if (!this.Country.Equals(str.Country))
			{
				eq = false;
				return eq;
			}
			if (this.Mailing_address != str.Mailing_address)
			{
				eq = false;
				return eq;
			}
			if (this.Billing_address != str.Billing_address)
			{
				eq = false;
				return eq;
			}
			if (this.Main_address != str.Main_address)
			{
				eq = false;
				return eq;
			}
			if (this.Satellite_office != str.Satellite_office)
			{
				eq = false;
				return eq;
			}
			if (this.Active_date != str.Active_date)
			{
				eq = false;
				return eq;
			}
			if (!this.Replication_key.Equals(str.Replication_key))
			{
				eq = false;
				return eq;
			}
			return eq;
		}
		/// <summary>
		/// Constructor
		/// </summary>
		public Address() {
		}
		/// <summary>
		/// serialize structure
		/// </summary>
		public string structToWire()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("ST[16]250%");
			StringBuilder body = new StringBuilder();
			body.Append(XFProtocol.fieldToWire(f_Address_id,fieldAttributes[0]));
			body.Append(XFProtocol.fieldToWire(f_Customer_id,fieldAttributes[1]));
			body.Append(XFProtocol.fieldToWire(f_Address_type,fieldAttributes[2]));
			body.Append(XFProtocol.fieldToWire(f_Address1,fieldAttributes[3]));
			body.Append(XFProtocol.fieldToWire(f_Address2,fieldAttributes[4]));
			body.Append(XFProtocol.fieldToWire(f_Address3,fieldAttributes[5]));
			body.Append(XFProtocol.fieldToWire(f_City,fieldAttributes[6]));
			body.Append(XFProtocol.fieldToWire(f_Postal_code,fieldAttributes[7]));
			body.Append(XFProtocol.fieldToWire(f_State,fieldAttributes[8]));
			body.Append(XFProtocol.fieldToWire(f_Country,fieldAttributes[9]));
			body.Append(XFProtocol.fieldToWire(f_Mailing_address,fieldAttributes[10]));
			body.Append(XFProtocol.fieldToWire(f_Billing_address,fieldAttributes[11]));
			body.Append(XFProtocol.fieldToWire(f_Main_address,fieldAttributes[12]));
			body.Append(XFProtocol.fieldToWire(f_Satellite_office,fieldAttributes[13]));
			body.Append(XFProtocol.fieldToWire(f_Active_date,fieldAttributes[14]));
			body.Append(XFProtocol.fieldToWire(f_Replication_key,fieldAttributes[15]));
			body.Append("^");
			sb.Append(body.Length+"#"+body.ToString()+";");
			return sb.ToString();
		}
 
		/// <summary>
		/// deserialize structure
		/// </summary>
		public void wireToStruct(SynMessage reply)
		{
			f_Address_id = XFProtocol.wireToint(reply);
			f_Customer_id = XFProtocol.wireToint(reply);
			f_Address_type = (Address_type)XFProtocol.wireToint(reply);
			f_Address1 = XFProtocol.wireTostring(reply);
			f_Address2 = XFProtocol.wireTostring(reply);
			f_Address3 = XFProtocol.wireTostring(reply);
			f_City = XFProtocol.wireTostring(reply);
			f_Postal_code = XFProtocol.wireTostring(reply);
			f_State = XFProtocol.wireTostring(reply);
			f_Country = XFProtocol.wireTostring(reply);
			f_Mailing_address = XFProtocol.wireTobool(reply);
			f_Billing_address = XFProtocol.wireTobool(reply);
			f_Main_address = XFProtocol.wireTobool(reply);
			f_Satellite_office = XFProtocol.wireTobool(reply);
			f_Active_date = XFProtocol.wireToDateTime(reply,fieldAttributes[14]);
			f_Replication_key = XFProtocol.wireTostring(reply);
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
