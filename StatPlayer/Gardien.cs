namespace StatPlayer
{
    class Gardien:Joueur
    {
        public Gardien(Joueur joueur) : base(joueur)
        {
        }
        public Gardien(string nom, string position, uint match, uint but, uint passe) : base(nom, position, match, but, passe)
        {
        }
    }
    
}