namespace Project1
{
    public class TileType
    {
        public const byte FLOOR = 0;
        public const byte WALL = 1;
        public const byte ENTRY = 2;
        public const byte EXIT = 3;
        public const byte EXIT_LOCKED = 4;

        // 100-199 are KEYS
        public const byte KEY = 100;

        /*-----------------
		 * convert from characrter to integer
		 * using TileType constants
		 */
        public static byte CharToByte(char c)
        {
            if (c == '#') return TileType.WALL;
            if (c == '.') return TileType.FLOOR;
            if (c == 's') return TileType.ENTRY;
            if (c == 'e') return TileType.EXIT;
            if (c == 'E') return TileType.EXIT_LOCKED;


            if (c == 'k') return TileType.KEY;

            // default - return a walkable = 0
            return 0;
        }
    }
}
