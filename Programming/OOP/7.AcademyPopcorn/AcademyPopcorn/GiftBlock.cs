using System.Collections.Generic;

namespace AcademyPopcorn
{
    public class GiftBlock : Block
    {
        public GiftBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            IsDestroyed = true;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> produceObjects = new List<GameObject>();
            if (this.IsDestroyed)
            {
               produceObjects.Add(new Gift(this.topLeft));
            }
            return produceObjects;
        }
    }
}
