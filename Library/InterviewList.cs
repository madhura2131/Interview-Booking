using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Library
{
    [XmlRoot("InterviewList")]
    [XmlInclude(typeof(Architecture))]
    [XmlInclude(typeof(Business))]
    [XmlInclude(typeof(InformationTechnology))]
    public class InterviewList:IDisposable
    {
        private List<Interviews> interviews;
        [XmlArray("Interviews")]
        [XmlArrayItem("Interview", typeof(Interviews))]
        public List<Interviews> Interviews { get => interviews; set => interviews = value; }

        public InterviewList()
        {
            Interviews = new List<Interviews>();
        }

        public void Add(Interviews ap)
        {
            Interviews.Add(ap);
        }
        public void Remove(Interviews ap)
        {
            Interviews.Remove(ap);
        }

        public void Sort()
        {
            Interviews.Sort();
        }

        public int Count
        {
            get
            {
                return Interviews.Count;
            }
        }


        public IEnumerator<Interviews> GetEnumerator()
        {
            return ((IEnumerable<Interviews>)Interviews).GetEnumerator();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
