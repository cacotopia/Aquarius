// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Counters
{
    [DataContract(Namespace = "http://schemas.thatindigogirl.com/samples/2006/06")]
    public class CounterInfo
    {
        private int m_id;
        private int m_counterValue;

        [DataMember]
        public int Id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        [DataMember]
        public int CounterValue
        {
            get { return m_counterValue; }
            set { m_counterValue = value; }
        }
    }
}
