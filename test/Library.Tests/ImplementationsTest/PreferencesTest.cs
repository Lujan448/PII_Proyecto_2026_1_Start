using NUnit.Framework;
using Library;
using System.Collections.Generic;
namespace LibraryTests
{
    [TestFixture]
    public class PreferenceTests
    {
        [Test]
        public void Select_IfAttributeIsAdded_ItsInPreferences()
        {
            Preferences preferences = new Preferences();
            preferences.Select("Acción", true);
            Assert.That(preferences.Preference.ContainsKey("Acción"), Is.True);
            Assert.That(preferences.Preference["Acción"], Is.True);
        }

        [Test]
        public void Select_IfAttributeIsAddedWithFalse_ItsStoredAsFalse()
        {
            Preferences preferences = new Preferences();
            preferences.Select("Acción", false);
            Assert.That(preferences.Preference["Acción"], Is.False);
        }
    }      
}
