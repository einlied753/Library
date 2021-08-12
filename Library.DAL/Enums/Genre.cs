using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Library.DAL.Enums
{
    /// <summary>
    /// Genre of books
    /// </summary>
    public enum Genre
    {
        [EnumMember(Value ="detective")]
        Detective,

        [EnumMember(Value = "historical")]
        Historical,

        [EnumMember(Value = "adventureFiction")]
        AdventureFiction,

        [EnumMember(Value = "classic")]
        Classic,

        [EnumMember(Value = "epic")]
        Epic,

        [EnumMember(Value = "western")]
        Western,

        [EnumMember(Value = "comedy")]
        Comedy,

        [EnumMember(Value = "crimeFiction")]
        CrimeFiction,

        [EnumMember(Value = "fantasy")]
        Fantasy,

        [EnumMember(Value = "scienceFiction")]
        ScienceFiction

    }
}
