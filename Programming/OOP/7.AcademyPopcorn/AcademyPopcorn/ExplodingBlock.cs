using System.Collections.Generic;

namespace AcademyPopcorn
{
    public class ExplodingBlock : Block
    {
        public const char Symbol1 = 'X';
        public new const string CollisionGroupString = "unpassableBlock";
        public ExplodingBlock(MatrixCoords topLeft)
            :base(topLeft)
        {
            this.body[0, 0] = Symbol1;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            base.RespondToCollision(collisionData);
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> produceObjects = new List<GameObject>();
            if (this.IsDestroyed)
            {
                produceObjects.Add(new Explosion(this.topLeft, new MatrixCoords(-1, 0)));
                produceObjects.Add(new Explosion(this.topLeft, new MatrixCoords(1, 0)));
                produceObjects.Add(new Explosion(this.topLeft, new MatrixCoords(0, 1)));
                produceObjects.Add(new Explosion(this.topLeft, new MatrixCoords(0, -1)));
            }
            return produceObjects;
        }
    }
}
