using System;
using System.Net;
using SpellChecker.Contracts;

namespace SpellChecker.Core
{

    /// <summary>
    /// This is a dictionary based spell checker that uses dictionary.com to determine if
    /// a word is spelled correctly.
    /// 
    /// The URL to do this looks like this: http://dictionary.reference.com/browse/<word>
    /// where <word> is the word to be checked.
    /// 
    /// We look for something in the response that gives us a clear indication whether the
    /// word is spelled correctly or not.
    /// </summary>
    public class DictionaryDotComSpellChecker : ISpellChecker
    {

        public bool Check(string word)
        {
            var urif = Uri.TryCreate("http://dictionary.reference.com/browse/" + word, UriKind.Absolute, out var dictionaryUri);
            HttpWebRequest dictionaryReqest = (HttpWebRequest)WebRequest.Create(dictionaryUri);
            try
            {
                 //Getting the Web Response.
                HttpWebResponse response = dictionaryReqest.GetResponse() as HttpWebResponse;
                //Returns TRUE if the Status code == 200
                response.Close();
                return true;
            }
            catch
            {
                //Any exception will returns false.
                return false;
            }
        }

    }

}
