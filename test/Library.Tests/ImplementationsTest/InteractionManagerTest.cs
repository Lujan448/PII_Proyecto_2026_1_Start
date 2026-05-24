using Library;
namespace LibraryTests
{
    [TestFixture]
    public class InteractionManagerTests
    {
        [Test]
        public void AddInteraction_IfInteractionIsAdded_ItsInList()
        {
            InteractionManager interactionManager = new InteractionManager();
            Interactions interactions = new Interactions();
            interactionManager.AddInteraction(interactions);
            Assert.That(interactionManager.Interact.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddNewInteraction_IfInteractionIsNotAdd_ItsNotInList()
        {
            InteractionManager interactionManager = new InteractionManager();
            Interactions interactions = new Interactions();
            Assert.That(interactionManager.Interact.Count, Is.Not.EqualTo(1));
        }

        [Test]
        public void RemoveInteraction_IfInteractionIsRemoved_InteractionIsNotInList()
        {
            InteractionManager interactionManager = new InteractionManager();
            Interactions interactions = new Interactions();
            interactionManager.AddInteraction(interactions);
            interactionManager.RemoveInteraction(interactions);
            Assert.That(interactionManager.Interact, Does.Not.Contain(interactions));
        }

        [Test]
        public void RemoveInteraction_IfInteractionIsNotRemoved_InteractionIsInList()
        {
            InteractionManager interactionManager = new InteractionManager();
            Interactions interactions = new Interactions();
            interactionManager.AddInteraction(interactions);
            Assert.That(interactionManager.Interact, Does.Contain(interactions));
        }
    }
}

