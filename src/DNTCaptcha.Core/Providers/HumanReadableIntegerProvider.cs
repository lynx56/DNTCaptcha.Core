using System.Collections.Generic;
using System.Linq;
using DNTCaptcha.Core.Contracts;

namespace DNTCaptcha.Core.Providers
{
    /// <summary>
    /// Convert a number into words
    /// </summary>
    public class HumanReadableIntegerProvider : ICaptchaTextProvider
    {
        private readonly IDictionary<Language, string> _and = new Dictionary<Language, string>
        {
            { Language.English, " " },
            { Language.Persian, " و " },
            { Language.Norwegian, " og " },
            { Language.Italian, " " },
            { Language.Russian, " " }
        };

        private readonly IList<NumberWord> _numberWords = new List<NumberWord>
        {
            new NumberWord { Group= DigitGroup.Ones, Language= Language.English, Names=
                new List<string> { string.Empty, "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" }},
            new NumberWord { Group= DigitGroup.Ones, Language= Language.Persian, Names=
                new List<string> { string.Empty, "یک", "دو", "سه", "چهار", "پنج", "شش", "هفت", "هشت", "نه" }},
            new NumberWord { Group= DigitGroup.Ones, Language= Language.Norwegian, Names=
                new List<string> { string.Empty, "en", "to", "tre", "fire", "fem", "seks", "syv", "åtte", "ni" }},
            new NumberWord { Group= DigitGroup.Ones, Language= Language.Italian, Names=
                new List<string> { string.Empty, "Uno", "Due", "Tre", "Quattro", "Cinque", "Sei", "Sette", "Otto", "Nove" }},
            new NumberWord { Group= DigitGroup.Ones, Language= Language.Russian, Names=
                new List<string> { string.Empty, "Один", "Два", "Три", "Четыре", "Пять", "Шесть", "Семь", "Восемь", "Девять" }},

            new NumberWord { Group= DigitGroup.Teens, Language= Language.English, Names=
                new List<string> { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" }},
            new NumberWord { Group= DigitGroup.Teens, Language= Language.Persian, Names=
                new List<string> { "ده", "یازده", "دوازده", "سیزده", "چهارده", "پانزده", "شانزده", "هفده", "هجده", "نوزده" }},
            new NumberWord { Group= DigitGroup.Teens, Language= Language.Norwegian, Names=
                new List<string> { "ti", "elleve", "tolv", "tretten", "fjorten", "femten", "seksten", "sytten", "atten", "nitten" }},
            new NumberWord { Group= DigitGroup.Teens, Language= Language.Italian, Names=
                new List<string> { "Dieci", "Undici", "Dodici", "Tredici", "Quattordici", "Quindici", "Sedici", "Diciassette", "Diciotto", "Diciannove" }},
            new NumberWord { Group= DigitGroup.Teens, Language= Language.Russian, Names=
                new List<string> { "Десять", "Одиннадцать", "Двенадцать", "Тринадцать", "Четырнадцать", "Пятнадцать", "Шестнадцать", "Семнадцать", "Восемнадцать", "Девятнацать" }},

            new NumberWord { Group= DigitGroup.Tens, Language= Language.English, Names=
                new List<string> { "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" }},
            new NumberWord { Group= DigitGroup.Tens, Language= Language.Persian, Names=
                new List<string> { "بیست", "سی", "چهل", "پنجاه", "شصت", "هفتاد", "هشتاد", "نود" }},
            new NumberWord { Group= DigitGroup.Tens, Language= Language.Norwegian, Names=
                new List<string> { "tjue", "tretti", "førti", "femti", "seksti", "sytti", "åtti", "nitti" }},
            new NumberWord { Group= DigitGroup.Tens, Language= Language.Italian, Names=
                new List<string> { "Venti", "Trenta", "Quaranta", "Cinquanta", "Sessanta", "Settanta", "Ottanta", "Novanta" }},
            new NumberWord { Group= DigitGroup.Tens, Language= Language.Russian, Names=
                new List<string> { "Двадцать", "Тридцать", "Сорок", "Пятьдесят", "Шестьдесят", "Семьдесят", "Восемьдесят", "Девяносто" }},

            new NumberWord { Group= DigitGroup.Hundreds, Language= Language.English, Names=
                new List<string> {string.Empty, "One Hundred", "Two Hundred", "Three Hundred", "Four Hundred",
                    "Five Hundred", "Six Hundred", "Seven Hundred", "Eight Hundred", "Nine Hundred" }},
            new NumberWord { Group= DigitGroup.Hundreds, Language= Language.Persian, Names=
                new List<string> {string.Empty, "یکصد", "دویست", "سیصد", "چهارصد", "پانصد", "ششصد", "هفتصد", "هشتصد" , "نهصد" }},
            new NumberWord { Group= DigitGroup.Hundreds, Language= Language.Norwegian, Names=
                new List<string> {string.Empty, "ett hundre", "to hundre", "tre hundre", "fire hundre", "fem hundre", "seks hundre", "syv hundre", "åtte hundre", "ni hundre" }},
            new NumberWord { Group= DigitGroup.Hundreds, Language= Language.Italian, Names=
                new List<string> {string.Empty, "Cento", "Duecento", "Trecento", "Quattrocento", "Cinquecento", "Seicento", "Settecento", "Ottocento", "Novecento" }},
            new NumberWord { Group= DigitGroup.Hundreds, Language= Language.Russian, Names=
                new List<string> {string.Empty, "Одна тысяча", "Две тысячи", "Три тысячи", "Четыре тысячи", "Пять тысяч", "Шесть тысяч", "Семь тысяч", "Восемь тысяч", "Девять тысяч" }},

            new NumberWord { Group= DigitGroup.Thousands, Language= Language.English, Names=
              new List<string> { string.Empty, " Thousand", " Million", " Billion"," Trillion", " Quadrillion", " Quintillion", " Sextillian",
            " Septillion", " Octillion", " Nonillion", " Decillion", " Undecillion", " Duodecillion", " Tredecillion",
            " Quattuordecillion", " Quindecillion", " Sexdecillion", " Septendecillion", " Octodecillion", " Novemdecillion",
            " Vigintillion", " Unvigintillion", " Duovigintillion", " 10^72", " 10^75", " 10^78", " 10^81", " 10^84", " 10^87",
            " Vigintinonillion", " 10^93", " 10^96", " Duotrigintillion", " Trestrigintillion" }},
            new NumberWord { Group= DigitGroup.Thousands, Language= Language.Persian, Names=
              new List<string> { string.Empty, " هزار", " میلیون", " میلیارد"," تریلیون", " Quadrillion", " Quintillion", " Sextillian",
            " Septillion", " Octillion", " Nonillion", " Decillion", " Undecillion", " Duodecillion", " Tredecillion",
            " Quattuordecillion", " Quindecillion", " Sexdecillion", " Septendecillion", " Octodecillion", " Novemdecillion",
            " Vigintillion", " Unvigintillion", " Duovigintillion", " 10^72", " 10^75", " 10^78", " 10^81", " 10^84", " 10^87",
            " Vigintinonillion", " 10^93", " 10^96", " Duotrigintillion", " Trestrigintillion" }},
            new NumberWord { Group= DigitGroup.Thousands, Language= Language.Norwegian, Names=
              new List<string> { string.Empty, " tusen", " million", " milliard"," billion", " billiard", " trillion", " trilliard",
            " kvadrillion", " kvintillion", " sekstillion", " septillion", " oktillion", " nonillion", " desillion",
            // Not translated the next
            " Quattuordecillion", " Quindecillion", " Sexdecillion", " Septendecillion", " Octodecillion", " Novemdecillion",
            " Vigintillion", " Unvigintillion", " Duovigintillion", " 10^72", " 10^75", " 10^78", " 10^81", " 10^84", " 10^87",
            " Vigintinonillion", " 10^93", " 10^96", " Duotrigintillion", " Trestrigintillion" }},
            new NumberWord { Group= DigitGroup.Thousands, Language= Language.Italian, Names=
              new List<string> { string.Empty, "mila", "Milioni", "Miliardi","Bilioni", "Biliardi", "Trilioni", "Triliardi",
            " Quadrilioni", "Quadriliardi", "Quintilioni", "Quintiliardi", "Sistilioni", "Sistiliardi", "Settilioni",
            " Settiliardi", " Ottilioni", "Ottiliardi", "Novilioni", "Noviliardi", "Decilioni",
            " Deciliardi", "Undicilioni", "Undiciliardi ", "Dodicilioni", "Dodiciliardi", "Tredicilioni", "Trediciliardi", "Quattordicilioni", "Quattordiciliardi",
            "Quindicilioni", "Quindiciliardi", "Sedicilioni", "Sediciliardi", "Diciasettilioni" }},
             new NumberWord { Group= DigitGroup.Thousands, Language= Language.Russian, Names=
              new List<string> { string.Empty, " Тысяч", " Миллион", " Миллиард"," Триллион", " Квадриллион", " Квинтиллион", " Секстиллион",
            " Септиллион", " Октиллион", " Нониллион", " Дециллион", " Ундециллион", " Дуодециллион", " Тредециллион",
            " Кваттордециллион", " Квиндециллион", " Сексдециллион", " Септендециллион", " Октодециллион", " Новемдециллион",
            " Вигинтиллион", " Unvigintillion", " Duovigintillion", " 10^72", " 10^75", " 10^78", " 10^81", " 10^84", " 10^87",
            " Vigintinonillion", " 10^93", " 10^96", " Duotrigintillion", " Trestrigintillion" }},
        };

        private readonly IDictionary<Language, string> _negative = new Dictionary<Language, string>
        {
            { Language.English, "Negative " },
            { Language.Persian, "منهای " },
            { Language.Norwegian, "Negativ" },
            { Language.Italian, "Negativo" },
            { Language.Russian, "Минус" }
        };

        private readonly IDictionary<Language, string> _zero = new Dictionary<Language, string>
        {
            { Language.English, "Zero" },
            { Language.Persian, "صفر" },
            { Language.Norwegian, "Null" },
            { Language.Italian, "Zero" },
            { Language.Russian, "Ноль" }
        };

        /// <summary>
        /// display a numeric value using the equivalent text
        /// </summary>
        /// <param name="number">input number</param>
        /// <param name="language">local language</param>
        /// <returns>the equivalent text</returns>
        public string GetText(long number, Language language)
        {
            return NumberToText(number, language);
        }

        /// <summary>
        /// display a numeric value using the equivalent text
        /// </summary>
        /// <param name="number">input number</param>
        /// <param name="language">local language</param>
        /// <returns>the equivalent text</returns>
        public string NumberToText(int number, Language language)
        {
            return NumberToText((long)number, language);
        }

        /// <summary>
        /// display a numeric value using the equivalent text
        /// </summary>
        /// <param name="number">input number</param>
        /// <param name="language">local language</param>
        /// <returns>the equivalent text</returns>
        public string NumberToText(uint number, Language language)
        {
            return NumberToText((long)number, language);
        }

        /// <summary>
        /// display a numeric value using the equivalent text
        /// </summary>
        /// <param name="number">input number</param>
        /// <param name="language">local language</param>
        /// <returns>the equivalent text</returns>
        public string NumberToText(byte number, Language language)
        {
            return NumberToText((long)number, language);
        }

        /// <summary>
        /// display a numeric value using the equivalent text
        /// </summary>
        /// <param name="number">input number</param>
        /// <param name="language">local language</param>
        /// <returns>the equivalent text</returns>
        public string NumberToText(decimal number, Language language)
        {
            return NumberToText((long)number, language);
        }

        /// <summary>
        /// display a numeric value using the equivalent text
        /// </summary>
        /// <param name="number">input number</param>
        /// <param name="language">local language</param>
        /// <returns>the equivalent text</returns>
        public string NumberToText(double number, Language language)
        {
            return NumberToText((long)number, language);
        }

        /// <summary>
        /// display a numeric value using the equivalent text
        /// </summary>
        /// <param name="number">input number</param>
        /// <param name="language">local language</param>
        /// <returns>the equivalent text</returns>
        public string NumberToText(long number, Language language)
        {
            if (number == 0)
            {
                return _zero[language];
            }

            if (number < 0)
            {
                return _negative[language] + NumberToText(-number, language);
            }

            return wordify(number, language, string.Empty, 0);
        }

        private string getName(int idx, Language language, DigitGroup group)
        {
            return _numberWords.First(x => x.Group == group && x.Language == language).Names[idx];
        }

        private string wordify(long number, Language language, string leftDigitsText, int thousands)
        {
            if (number == 0)
            {
                return leftDigitsText;
            }

            var wordValue = leftDigitsText;
            if (wordValue.Length > 0)
            {
                wordValue += _and[language];
            }

            if (number < 10)
            {
                wordValue += getName((int)number, language, DigitGroup.Ones);
            }
            else if (number < 20)
            {
                wordValue += getName((int)(number - 10), language, DigitGroup.Teens);
            }
            else if (number < 100)
            {
                wordValue += wordify(number % 10, language, getName((int)(number / 10 - 2), language, DigitGroup.Tens), 0);
            }
            else if (number < 1000)
            {
                wordValue += wordify(number % 100, language, getName((int)(number / 100), language, DigitGroup.Hundreds), 0);
            }
            else
            {
                wordValue += wordify(number % 1000, language, wordify(number / 1000, language, string.Empty, thousands + 1), 0);
            }

            if (number % 1000 == 0) return wordValue;
            return wordValue + getName(thousands, language, DigitGroup.Thousands);
        }
    }
}