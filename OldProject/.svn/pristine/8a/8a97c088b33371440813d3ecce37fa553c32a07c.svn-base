using FinalGame.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.ComponentModel;

namespace FinalGame.MapElements
{
    public class Map : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _currentFloor;

        public Tile[][] layout;
        private Random rand = new Random();
        public int x {get; set;}
        public int y{get; set;}
        public int currentFloor
        {
            get { return _currentFloor; }
            set
            {
                _currentFloor = value;

                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("currentFloor"));
            }
        }
        public Vector2D start;
        public Vector2D playerPosition;
        public const int FOG_DISTANCE = 3;

        EnumToImageConverter BTIC = new EnumToImageConverter();
        BoolToPlayer BTP = new BoolToPlayer();
        TileImageConverter TIC = new TileImageConverter();

        Binding imageBinding;
        Binding contentBinding;
        Binding playerBinding;
        Binding visibleBinding;
        Binding directionBinding;
        MultiBinding tileImageBinding;

        public Map(int currFloor)
        {
            init(currFloor);

            int x, y;
            x = rand.Next(20, 46);
            y = rand.Next(x-5, x+5);
            //currentFloor = maxFloorReached;
            this.x = x;
            this.y = y;

            layout = new Tile[x][];

            for (int i = 0; i < x; i++)
            {
                layout[i] = new Tile[y];
            }
        }
        public Map(int mapSize, int currFloor)
        {
            init(currFloor);
            layout = new Tile[mapSize][];

            x = mapSize;
            y = mapSize;

            for (int i = 0; i < mapSize; i++)
            {
                layout[i] = new Tile[mapSize];
            }
        }
        public Map(int x, int y, int currFloor)
        {
            init(currFloor);
            layout = new Tile[x][];

            this.x = x;
            this.y = y;

            for (int i = 0; i < x; i++)
            {
                layout[i] = new Tile[y];
            }
        }
        public Map(int minX, int maxX, int minY, int maxY, int currFloor)
        {
            init(currFloor);

            int x, y;
            x = rand.Next(minX, maxX);
            y = rand.Next(minY, maxY);

            this.x = x;
            this.y = y;

            layout = new Tile[x][];

            for (int i = 0; i < x; i++)
            {
                layout[i] = new Tile[y];
            }
        }
        public Map(Tile[][] layout, int currFloor)
        {
            this.layout = layout;
        }

        private void init(int currFloor)
        {
            currentFloor = currFloor;

            imageBinding = new Binding("type");
            contentBinding = new Binding("type");
            playerBinding = new Binding("playerIsHere");
            visibleBinding = new Binding("visible");
            directionBinding = new Binding("direction");
            tileImageBinding = new MultiBinding();

            tileImageBinding.Bindings.Add(contentBinding);
            tileImageBinding.Bindings.Add(playerBinding);
            tileImageBinding.Bindings.Add(visibleBinding);
            tileImageBinding.Bindings.Add(directionBinding);
            tileImageBinding.Converter = TIC;
            //maxFloorReached++;
        }
        public void populate()
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    layout[i][j] = new Tile();
                    layout[i][j].type = TileType.closed;
                    layout[i][j].visible = false;
                    layout[i][j].DataContext = layout[i][j];
                    layout[i][j].SetBinding(Tile.BackgroundProperty, tileImageBinding);
                }
            }
            
            if (currentFloor == 0)
            {
                generateTestMap();
            }
            else if(currentFloor%5==0)
            {
                generateBossLevel();
            }
            else
            {
                generateRandomMap();
            }
        }

        public void playerMoveUp()
        {
            if (playerPosition.y - 1 >= 0 && layout[playerPosition.x][playerPosition.y - 1].type != TileType.closed && playerPosition.y - 1 >= 0 && layout[playerPosition.x][playerPosition.y - 1].type != TileType.decoration && playerPosition.y - 1 >= 0 && layout[playerPosition.x][playerPosition.y - 1].type != TileType.counter)
            {
                layout[playerPosition.x][playerPosition.y].playerIsHere = false;                
                playerPosition.y -= 1;
                layout[playerPosition.x][playerPosition.y].playerIsHere = true;
            }
            layout[playerPosition.x][playerPosition.y].direction = PlayerDirections.North;
            fogOfWar();
        }
        public void playerMoveDown()
        {
            if (playerPosition.y + 1 <= y && layout[playerPosition.x][playerPosition.y + 1].type != TileType.closed && playerPosition.y + 1 <= y && layout[playerPosition.x][playerPosition.y + 1].type != TileType.decoration && playerPosition.y + 1 <= y && layout[playerPosition.x][playerPosition.y + 1].type != TileType.counter)
            {
                layout[playerPosition.x][playerPosition.y].playerIsHere = false;
                playerPosition.y += 1;
                layout[playerPosition.x][playerPosition.y].playerIsHere = true;
            }
            layout[playerPosition.x][playerPosition.y].direction = PlayerDirections.South;
            fogOfWar();
        }
        public void playerMoveLeft()
        {
            if (playerPosition.x - 1 <= x && layout[playerPosition.x - 1][playerPosition.y].type != TileType.closed && playerPosition.x - 1 <= x && layout[playerPosition.x - 1][playerPosition.y].type != TileType.decoration && playerPosition.x - 1 <= x && layout[playerPosition.x - 1][playerPosition.y].type != TileType.counter)
            {
                layout[playerPosition.x][playerPosition.y].playerIsHere = false;
                playerPosition.x -= 1;
                layout[playerPosition.x][playerPosition.y].playerIsHere = true;
            }
            layout[playerPosition.x][playerPosition.y].direction = PlayerDirections.West;            
            fogOfWar();
        }
        public void playerMoveRight()
        {
            if (playerPosition.x + 1 <= x && layout[playerPosition.x + 1][playerPosition.y].type != TileType.closed && playerPosition.x + 1 <= x && layout[playerPosition.x + 1][playerPosition.y].type != TileType.decoration && playerPosition.x + 1 <= x && layout[playerPosition.x + 1][playerPosition.y].type != TileType.counter)
            {
                layout[playerPosition.x][playerPosition.y].playerIsHere = false;
                playerPosition.x += 1;
                layout[playerPosition.x][playerPosition.y].playerIsHere = true;
            }
            layout[playerPosition.x][playerPosition.y].direction = PlayerDirections.East;
            fogOfWar();
        }
        private void generateTestMap()
        {

            x = 7;
            y = 7;

            int playerX = 4;
            int playerY = 5;
            layout = new Tile[x][];

            for (int i = 0; i < x; i++)
            {
                layout[i] = new Tile[y];
            }
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    layout[i][j] = new Tile();
                    layout[i][j].type = TileType.closed;
                    layout[i][j].visible = false;
                    layout[i][j].DataContext = layout[i][j];
                    layout[i][j].SetBinding(Tile.BackgroundProperty, tileImageBinding);
                }
            }
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    layout[i][j].visible = true;
                    layout[i][j].type  = TileType.open;
                }
            }
            //generates the closed tiles
            foreach (Vector2D v in mapCoords.closedTiles)
            {
                layout[v.x][v.y].type = TileType.closed;
            }
            foreach (Vector2D v in mapCoords.exitTiles)
            {
                layout[v.x][v.y].type = TileType.end;
            }
            foreach (Vector2D v in mapCoords.monsterTiles)
            {
                layout[v.x][v.y].type = TileType.monster;
            }
            foreach (Vector2D v in mapCoords.trapTiles)
            {
                layout[v.x][v.y].type = TileType.trap;
            }
            foreach (Vector2D v in mapCoords.storeTiles)
            {
                layout[v.x][v.y].type = TileType.store;
            }
            foreach (Vector2D v in mapCoords.npcTiles)
            {
                layout[v.x][v.y].type = TileType.npc;
            }
            foreach (Vector2D v in mapCoords.decorationTiles)
            {
                layout[v.x][v.y].type = TileType.decoration;
            }
            foreach (Vector2D v in mapCoords.counterTiles)
            {
                layout[v.x][v.y].type = TileType.counter;
            }
            //closes the outer most walls
            for (int i = 0; i < x; i++)
            {
                layout[0][i].type = TileType.closed;
                layout[i][0].type = TileType.closed;
                layout[x-1][i].type = TileType.closed;
                layout[i][y-1].type = TileType.closed;
            }
            layout[playerX - 1][playerY - 1].type = TileType.start;
            playerPosition = new Vector2D(playerX - 1, playerY - 1);
            layout[playerX - 1][playerY - 1].playerIsHere = true;
        }
        private void generateBossLevel()
        {

            x = 9;
            y = 9;
            layout = new Tile[x][];

            for (int i = 0; i < x; i++)
            {
                layout[i] = new Tile[y];
            }
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    layout[i][j] = new Tile();
                    layout[i][j].type = TileType.closed;
                    layout[i][j].visible = true;
                    layout[i][j].DataContext = layout[i][j];
                    layout[i][j].SetBinding(Tile.BackgroundProperty, tileImageBinding);
                }
            }
            for (int i = 0; i < x-1; i++)
            {
                for (int j = 0; j < y-1; j++)
                {
                    layout[i][j].visible = true;
                    layout[i][j].type = TileType.open;
                }
            }
            foreach (Vector2D v in mapCoords.BossTile)
            {
                layout[v.x][v.y].type = TileType.monster;
            }
            for (int i = 0; i < x; i++)
            {
                layout[0][i].type = TileType.closed;
                layout[i][0].type = TileType.closed;
                layout[8][i].type = TileType.closed;
                layout[i][8].type = TileType.closed;
            }
            layout[4][7].type = TileType.start;
            playerPosition = new Vector2D(4, 7);
            layout[4][7].playerIsHere = true;
        }
        private void generateRandomMap(float percOpen = .60f,float percMonsters = .05f, float percTraps = .05f)
        {
            int numTiles = (x - 2) * (y - 2);
            int numToPopulate = (int)(numTiles * (percOpen));
            int numPopulated = 0;
            int direction;
            int numMonsters = (int)(numToPopulate * percMonsters);
            int numTrapsToPopulate = numToPopulate - numMonsters;
            int numTraps = (int)(numToPopulate * percTraps);

            Vector2D position;
            Vector2D nextPosition;
            start = new Vector2D(rand.Next(1,x-1), rand.Next(1,y-1));

            playerPosition = start;
            position = start;

            layout[start.x][start.y].type = TileType.start;
            layout[position.x][position.y].visible = false;
            layout[start.x][start.y].playerIsHere = true;

            List<Vector2D> populatedTiles = new List<Vector2D>();

            if (numToPopulate > numTiles)
                throw new Exception("number of tiles to populate is too great");

            while (numPopulated < numToPopulate)
            {
                direction = rand.Next(1, 5);
                switch (direction)
                {
                    case 1:
                        nextPosition = new Vector2D(position.x, position.y - 1);
                        break;
                    case 2:
                        nextPosition = new Vector2D(position.x + 1, position.y);
                        break;
                    case 3:
                        nextPosition = new Vector2D(position.x, position.y +1);
                        break;
                    case 4:
                        nextPosition = new Vector2D(position.x-1, position.y);
                        break;
                    default:
                        throw new Exception("Direction selection is broken");
                }

                if ((nextPosition.x > 1 && nextPosition.x < x - 1) && (nextPosition.y > 1 && nextPosition.y < y - 1))
                {
                    position = nextPosition;
                    if (layout[position.x][position.y].type == TileType.closed)
                    {
                        layout[position.x][position.y].visible = false;
                        layout[position.x][position.y].type = TileType.open;

                        populatedTiles.Add(new Vector2D(position.x,position.y));
                        numPopulated++;
                    }
                }
            }
            for (int i = 0; i < numMonsters; i++)
            {
                int monsterToBeInt =  rand.Next(numToPopulate - i);
                Vector2D monsterToBe = populatedTiles[monsterToBeInt];
                populatedTiles.Remove(populatedTiles[monsterToBeInt]);
                layout[monsterToBe.x][monsterToBe.y].type = TileType.monster;
                layout[monsterToBe.x][monsterToBe.y].monsterIsHere = true;
                layout[monsterToBe.x][monsterToBe.y].visible = false;
            }
            numToPopulate -= numMonsters;

            for (int i = 0; i < numTraps; i++)
            {
                int trapToBeInt = rand.Next(numToPopulate - i);
                Vector2D trapToBe = populatedTiles[trapToBeInt];
                populatedTiles.Remove(populatedTiles[trapToBeInt]);
                layout[trapToBe.x][trapToBe.y].type = TileType.trap;
                layout[trapToBe.x][trapToBe.y].visible = false;
            }
            numToPopulate -= numTraps;

            int exitInt = rand.Next(numToPopulate);
            Vector2D exit = populatedTiles[exitInt];
            layout[exit.x][exit.y].type = TileType.end;
            layout[exit.x][exit.y].visible = false;

            fogOfWar();
        }

        public void fogOfWar()
        {
            for(int i=0; i<layout.Length; i++)
            {
                for (int j = 0; j < layout[i].Length; j++)
                {
                    if (Math.Abs((i) - (playerPosition.x)) + Math.Abs((j) - (playerPosition.y)) <= FOG_DISTANCE)
                    {
                        if (!layout[i][j].visible)
                        {
                            layout[i][j].visible = true;
                        }
                    }
                }
            }
        }

    }
}