using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryDemo
{
    class Words
    {
        public enum PartOfSpeech { Noun, Verb, Adjective}

        public string Word { get; set; }
        public PartOfSpeech WordType;

        protected static List<Words> words = new List<Words>
        {
            new Words {Word = "Car", WordType = PartOfSpeech.Noun},
            new Words {Word = "House", WordType = PartOfSpeech.Noun},
            new Words {Word = "Fruit", WordType = PartOfSpeech.Noun},
            new Words {Word = "Night", WordType = PartOfSpeech.Noun},
            new Words {Word = "London", WordType = PartOfSpeech.Noun},
            new Words {Word = "Water", WordType = PartOfSpeech.Noun},
            new Words {Word = "Fast", WordType = PartOfSpeech.Adjective},
            new Words {Word = "Busy", WordType = PartOfSpeech.Adjective},
            new Words {Word = "Juicy", WordType = PartOfSpeech.Adjective},
            new Words {Word = "Calm", WordType = PartOfSpeech.Adjective},
            new Words {Word = "Anxious", WordType = PartOfSpeech.Adjective},
            new Words {Word = "Round", WordType = PartOfSpeech.Adjective},
            new Words {Word = "Start", WordType = PartOfSpeech.Verb},
            new Words {Word = "Bake", WordType = PartOfSpeech.Verb},
            new Words {Word = "Grow", WordType = PartOfSpeech.Verb},
            new Words {Word = "Kick", WordType = PartOfSpeech.Verb},
            new Words {Word = "Listen", WordType = PartOfSpeech.Verb},
            new Words {Word = "Stop", WordType = PartOfSpeech.Verb}
        };

        public string SelectList()
        {
            string list = "";
            return list = string.Join(", ", words.Select(item => item.Word.ToString()));
        }


        public string QueryPartOfSpeech(PartOfSpeech prtSpeech)
        {
            string partOfSpeech = "";
            return partOfSpeech = string.Join(", ", words.Where(item => item.WordType == prtSpeech)
                              .Select(item => item.Word.ToString()));     
        }

       public string QueryNoun()
        {
            return QueryPartOfSpeech(PartOfSpeech.Noun);
        }
        public string QueryVerb()
        {
            return QueryPartOfSpeech(PartOfSpeech.Verb);
        }

        public string QueryAdjective()
        {
            return QueryPartOfSpeech(PartOfSpeech.Adjective);
        }
    }
}
