using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace v1336.Model
{
    public class Department : AbstartDictionaryObject
    {
        public List<Nomenclature> Nomenclatures { get; set; }
        public List<CommentTheme> CommentThemes { get; set; }
    }
}
