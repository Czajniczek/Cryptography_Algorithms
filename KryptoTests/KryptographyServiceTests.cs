using Krypto;
using NUnit.Framework;

namespace KryptoTests
{
    public class KryptographyServiceTests
    {
        private KryptographyService service;

        [SetUp]
        public void Setup()
        {
            service = new KryptographyService();
        }

        #region ZADANIE 1
        [TestCase("CRYPTOGRAPHY", 3, "CTARPORPYYGH")]
        [TestCase("TestowanieSzyfrow", 5, "TiweneosaSrtwzfoy")]
        [TestCase("Kryptografia", 8, "Krypatiofgar")]
        [TestCase("SiecKomputerowa", 4, "SmoioprweKueact")]
        [TestCase("DoZakodowaniaTojestTekst", 7, "DaoiTtZnosaajkkweeoosTdt")]
        public void RailFenceEncode(string input, int key, string output)
        {
            var result = service.RailFenceEncode(input, key);

            Assert.AreEqual(output, result);
        }

        [TestCase("CTARPORPYYGH", 3, "CRYPTOGRAPHY")]
        [TestCase("TiweneosaSrtwzfoy", 5, "TestowanieSzyfrow")]
        [TestCase("Krypatiofgar", 8, "Kryptografia")]
        [TestCase("SmoioprweKueact", 4, "SiecKomputerowa")]
        [TestCase("DaoiTtZnosaajkkweeoosTdt", 7, "DoZakodowaniaTojestTekst")]
        public void RailFenceDecode(string input, int key, string output)
        {
            var result = service.RailFenceDecode(input, key);

            Assert.AreEqual(output, result);
        }
        #endregion

        #region ZADANIE 2
        [TestCase("CRYPTOGRAPHY", "YPCTRRAOPGHY")]
        [TestCase("TestowanieSzyfrow", "stToeniweayfSrzow")]
        [TestCase("Kryptografia", "ypKtrraofgia")]
        [TestCase("SiecKomputerowa", "ecSKipuotmowear")]
        [TestCase("DoZakodowaniaTojestTekst", "ZaDkoowoadaTnoistjTestek")]
        public void MatrixShift2AEncode(string input, string output)
        {
            var result = service.MatrixShift2AEncode(input);

            Assert.AreEqual(output, result);
        }

        [TestCase("YPCTRRAOPGHY", "CRYPTOGRAPHY")]
        [TestCase("stToeniweayfSrzow", "TestowanieSzyfrow")]
        [TestCase("ypKtrraofgia", "Kryptografia")]
        [TestCase("ecSKipuotmowear", "SiecKomputerowa")]
        [TestCase("ZaDkoowoadaTnoistjTestek", "DoZakodowaniaTojestTekst")]
        public void MatrixShift2ADecode(string input, string output)
        {
            var result = service.MatrixShift2ADecode(input);

            Assert.AreEqual(output, result);
        }
        #endregion

        #region ZADANIE 3
        #region 2B
        [TestCase("CRYPTOGRAPHY", "CONVENIENCE", "CYPTRHGYOARP")]
        [TestCase("TestowanieSzyfrow", "CONVENIENCE", "TzeoonSasfwwieytr")]
        [TestCase("Kryptografia", "CONVENIENCE", "Kaftrigyoarp")]
        [TestCase("SiecKomputerowa", "CONVENIENCE", "SrtKpemewouioca")]
        [TestCase("DoZakodowaniaTojestTekst", "CONVENIENCE", "DisaekjotnkdsZToewToatao")]
        public void MatrixShift2BEncode(string input, string key, string output)
        {
            var result = service.MatrixShift2BEncode(input, key);

            Assert.AreEqual(output, result);
        }

        [TestCase("CYPTRHGYOARP", "CONVENIENCE", "CRYPTOGRAPHY")]
        [TestCase("TzeoonSasfwwieytr", "CONVENIENCE", "TestowanieSzyfrow")]
        [TestCase("Kaftrigyoarp", "CONVENIENCE", "Kryptografia")]
        [TestCase("SrtKpemewouioca", "CONVENIENCE", "SiecKomputerowa")]
        [TestCase("DisaekjotnkdsZToewToatao", "CONVENIENCE", "DoZakodowaniaTojestTekst")]
        public void MatrixShift2BDecode(string input, string key, string output)
        {
            var result = service.MatrixShift2BDecode(input, key);

            Assert.AreEqual(output, result);
        }
        #endregion

        #region 2C
        [TestCase("CRYPTOGRAPHY", "CONVENIENCE", "CRYHOARPGPYT")]
        [TestCase("TestowanieSzyfrow", "CONVENIENCE", "TezwSwointfaesyor")]
        [TestCase("Kryptografia", "CONVENIENCE", "Kraioarpgfyt")]
        [TestCase("SiecKomputerowa", "CONVENIENCE", "SireoupcwmteoKa")]
        [TestCase("DoZakodowaniaTojestTekst", "CONVENIENCE", "DoienojewtosaTtdkaZaskoT")]
        public void MatrixShift2CEncode(string input, string key, string output)
        {
            var result = service.MatrixShift2CEncode(input, key);

            Assert.AreEqual(output, result);
        }

        [TestCase("CRYHOARPGPYT", "CONVENIENCE", "CRYPTOGRAPHY")]
        [TestCase("TezwSwointfaesyor", "CONVENIENCE", "TestowanieSzyfrow")]
        [TestCase("Kraioarpgfyt", "CONVENIENCE", "Kryptografia")]
        [TestCase("SireoupcwmteoKa", "CONVENIENCE", "SiecKomputerowa")]
        [TestCase("DoienojewtosaTtdkaZaskoT", "CONVENIENCE", "DoZakodowaniaTojestTekst")]
        public void MatrixShift2CDecode(string input, string key, string output)
        {
            var result = service.MatrixShift2CDecode(input, key);

            Assert.AreEqual(output, result);
        }
        #endregion
        #endregion

        #region ZADANIE 4
        [TestCase("CRYPTOGRAPHY", 7, 5, "TURGIZVUFGCR")]
        [TestCase("TestowanieSzyfrow", 7, 5, "IhbizdfsjhByrouzd")]
        [TestCase("Kryptografia", 7, 5, "Xurgizvufojf")]
        [TestCase("SiecKomputerowa", 7, 5, "BjhtXzlgpihuzdf")]
        [TestCase("DoZakodowaniaTojestTekst", 7, 5, "AzYfxzazdfsjfIzqhbiIhxbi")]
        public void CaesarEncode(string input, int a, int b, string output)
        {
            var result = service.CaesarEncode(input, a, b);

            Assert.AreEqual(output, result);
        }

        [TestCase("TURGIZVUFGCR", 7, 5, "CRYPTOGRAPHY")]
        [TestCase("IhbizdfsjhByrouzd", 7, 5, "TestowanieSzyfrow")]
        [TestCase("Xurgizvufojf", 7, 5, "Kryptografia")]
        [TestCase("BjhtXzlgpihuzdf", 7, 5, "SiecKomputerowa")]
        [TestCase("AzYfxzazdfsjfIzqhbiIhxbi", 7, 5, "DoZakodowaniaTojestTekst")]
        public void CaesarDecode(string input, int a, int b, string output)
        {
            var result = service.CaesarDecode(input, a, b);

            Assert.AreEqual(output, result);
        }
        #endregion

        #region ZADANIE 5
        [TestCase("CRYPTOGRAPHY", "BREAK", "DICPDPXVAZIP")]
        [TestCase("TestowanieSzyfrow", "BREAK", "UvwtyxrrioTqcfbpn")]
        [TestCase("Kryptografia", "BREAK", "Licpdpxvapjr")]
        [TestCase("SiecKomputerowa", "BREAK", "TzicUpdtudfiswk")]
        [TestCase("DoZakodowaniaTojestTekst", "BREAK", "EfDaupuswkozeTykvwtDfbwt")]
        public void VigenereEncode(string input, string key, string output)
        {
            var result = service.VigenereEncode(input, key);

            Assert.AreEqual(output, result);
        }

        [TestCase("DICPDPXVAZIP", "BREAK", "CRYPTOGRAPHY")]
        [TestCase("UvwtyxrrioTqcfbpn", "BREAK", "TestowanieSzyfrow")]
        [TestCase("Licpdpxvapjr", "BREAK", "Kryptografia")]
        [TestCase("TzicUpdtudfiswk", "BREAK", "SiecKomputerowa")]
        [TestCase("EfDaupuswkozeTykvwtDfbwt", "BREAK", "DoZakodowaniaTojestTekst")]
        public void VigenereDecode(string input, string key, string output)
        {
            var result = service.VigenereDecode(input, key);

            Assert.AreEqual(output, result);
        }
        #endregion
    }
}