using System.Collections.Generic;

namespace AcademyPopcorn
{
    public class MeteoriteBall : Ball
    {
        public const char Symbol = '*';
        public new const string CollisionGroupString = "unstoppableBall";
        public MeteoriteBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
            this.body[0, 0] = Symbol;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> produceObjects = new List<GameObject>();
            produceObjects.Add(new TrailObject(base.topLeft));
            return produceObjects;
        }
    }
}
