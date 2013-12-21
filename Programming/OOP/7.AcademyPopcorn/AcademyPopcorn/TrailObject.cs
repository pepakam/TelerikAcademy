namespace AcademyPopcorn
{
    public class TrailObject : GameObject
    {
        private int lifetime;

        public TrailObject(MatrixCoords topLeft, int lifetime=3)
            : base(topLeft, new char[,] { { '*' } })
        {
            this.Lifetime = lifetime;
        }

        public int Lifetime
        {
            get { return this.lifetime; }
            set { this.lifetime = value; }
        }

       
        public override void Update()
        {
            Lifetime--;
            if (Lifetime == 0)
            {
                this.IsDestroyed = true;
            }
        }
    }
}
