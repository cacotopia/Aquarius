// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
   
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Runtime.Serialization;

namespace PhotoManagerService
{
    [DataContract(Namespace = "http://schemas.thatindigogirl.com/samples/2006/06")]
    public class ReceiverFaultDetail
    {

        private string m_message;
        private string m_description;
        private bool m_contactAdministrator;

        public ReceiverFaultDetail(string message, bool contactAdmin)
            : this(message, "", contactAdmin)
        {
        }

        public ReceiverFaultDetail(string message, string description, bool contactAdmin)
        {
            this.m_message = message;
            this.m_description = description;
            this.m_contactAdministrator = contactAdmin;
        }

        [DataMember(Name = "Message", IsRequired = true, Order = 0)]
        public string Message
        {
            get { return m_message; }
            set { m_message = value; }
        }

        [DataMember(Name = "Description", IsRequired = false, Order = 1)]
        public string Description
        {
            get { return m_description; }
            set { m_description = value; }
        }

        [DataMember(Name = "ContactAdministrator", IsRequired = true, Order = 2)]
        public bool ContactAdministrator
        {
            get { return m_contactAdministrator; }
            set { m_contactAdministrator = value; }
        }

    }

    [DataContract(Namespace = "http://schemas.thatindigogirl.com/samples/2006/06")]
    public class SenderFaultDetail
    {

        private string m_message;
        private string m_description;
        private List<string> m_failedBodyElements = new List<string>();


        public SenderFaultDetail(string message, List<string> bodyElements)
            : this(message, "", bodyElements)
        {
        }

        public SenderFaultDetail(string message)
            : this(message, "", null)
        {
        }

        public SenderFaultDetail(string message, string description, List<string> bodyElements)
        {
            this.m_message = message;
            this.m_description = description;

            if (bodyElements != null)
                this.m_failedBodyElements = bodyElements;
        }

        [DataMember(Name = "Message", IsRequired = true, Order = 0)]
        public string Message
        {
            get { return m_message; }
            set { m_message = value; }
        }

        [DataMember(Name = "Description", IsRequired = false, Order = 1)]
        public string Description
        {
            get { return m_description; }
            set { m_description = value; }
        }

        [DataMember(Name = "FailedBodyElements", IsRequired = true, Order = 2)]
        public List<string> FailedBodyElements
        {
            get { return m_failedBodyElements; }
            set { m_failedBodyElements = value; }
        }

    }

}
