using System.Collections.Generic;

namespace AcademyPopcorn
{
    public class Gift : MovingObject
    {
        public Gift(MatrixCoords topLeft)
            : base(topLeft, new char[,] { { 'G' } }, new MatrixCoords(1, 0))
        {

        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "racket";
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        
        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> produceObjects = new List<GameObject>();
            if (!this.IsDestroyed) return produceObjects;
            produceObjects.Add(new ShoothingRacket(new MatrixCoords(this.topLeft.Row + 1, this.topLeft.Col-3), 6));
            produceObjects.RemoveAll(o => o is Racket);
            return produceObjects;
        }
    }
}
