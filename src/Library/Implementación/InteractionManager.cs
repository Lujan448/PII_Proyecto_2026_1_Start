namespace Library;

    public class InteractionManager
    {
        private List<Interactions> interact = new List<Interactions>();
        public List<Interactions> Interact
        {
            get { return interact; }
        }
    
        public void AddInteraction(Interactions interactions)
        {
            interact.Add(interactions); 
        }

        public void RemoveInteraction(Interactions interactions)
        {
            interact.Remove(interactions);
        }
    }