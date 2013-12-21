namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        const int WorldRows = 23;
        const int WorldCols = 40;
        const int RacketLength = 6;

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 2;
            int endRow = WorldRows;
            int endCol = WorldCols - 2;


            for (int i = startCol; i < endCol; i++)
            {
                Block currBlock = new Block(new MatrixCoords(startRow, i));


                //if (i == startCol + 7)
                //    currBlock = new ExplodingBlock(new MatrixCoords(startRow, i));
                currBlock = new GiftBlock(new MatrixCoords(startRow, i));
                //if (i > startCol + 3 && i < endCol - 25)
                //    currBlock = new UnpassableBlock(new MatrixCoords(startRow, i));

                engine.AddObject(currBlock);
            }

            for (int i = startRow; i < endRow; i++)
            {
                IndestructibleBlock wallBlockLeft = new IndestructibleBlock(new MatrixCoords(i, startCol - 1));
                engine.AddObject(wallBlockLeft);

                IndestructibleBlock wallBlockRight = new IndestructibleBlock(new MatrixCoords(i, endCol));
                engine.AddObject(wallBlockRight);
            }


            //for (int i = 6; i < 9; i++)
            //{
            //    TrailObject trailObject = new TrailObject(new MatrixCoords(startRow + 1, i));
            //    engine.AddObject(trailObject);
            //}

            Ball theBall = new Ball(new MatrixCoords(WorldRows / 2, 0),
                new MatrixCoords(1, 1));
            engine.AddObject(theBall);

            //MeteoriteBall theMeteoriteBall = new MeteoriteBall(new MatrixCoords(WorldRows / 2, 1), new MatrixCoords(1, 1));
            //engine.AddObject(theMeteoriteBall);

            //UnstoppableBall theUnstoppableBall = new UnstoppableBall(new MatrixCoords(WorldRows / 2, 1),   new MatrixCoords(-1, 1));
            //engine.AddObject(theUnstoppableBall);


            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2 - 3), RacketLength);

            engine.AddObject(theRacket);
        }

        static void Main()
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();


            Engine gameEngine = new Engine(renderer, keyboard);

            keyboard.OnLeftPressed += (sender, eventInfo) => gameEngine.MovePlayerRacketLeft();

            keyboard.OnRightPressed += (sender, eventInfo) => gameEngine.MovePlayerRacketRight();

            keyboard.OnActionPressed += (sender, eventInfo) => gameEngine.ShootPlayerRacket();

            Initialize(gameEngine);

            gameEngine.Run();
        }
    }
}
