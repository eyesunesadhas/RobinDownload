
using System.Linq;

namespace RobinHoodDownload.DataModels.Common
{
    public class DuplicateRecordData<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateRecordData&lt;T&gt;"/> class.
        /// </summary>
        public DuplicateRecordData()
        {
            this.DuplicateRecord = null;
            this.Count = 0;
        }

        /// <summary>
        /// Gets or sets the duplicate record count.
        /// </summary>
        public int Count
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the duplicate record.
        /// </summary>
        public IGrouping<T, T> DuplicateRecord
        {
            get;
            set;
        }
    }
}