namespace AcademyPopcorn
{
    public class UnpassableBlock : IndestructibleBlock
    {
        public const char Symbol1 = '!';
        public new const string CollisionGroupString = "unpassableBlock";

        public UnpassableBlock(MatrixCoords upperLeft)
            : base(upperLeft)
        {
            this.body[0, 0] = UnpassableBlock.Symbol1;
        }

        public override string GetCollisionGroupString()
        {
            return UnpassableBlock.CollisionGroupString;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {          
                this.IsDestroyed = false;                         
        }
    }
}
