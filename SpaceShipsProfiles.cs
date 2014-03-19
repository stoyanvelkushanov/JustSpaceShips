using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JustSpaceShips
{
    public static class SpaceShipsProfiles
    {
        public static char[,] scout = {
                                            {'|','_','|'},  
                                            {'|','=','|'},
                                            {' ','V',' '},
                                           };

        public static char[,] coursair = {
                                            {'_','_','T','_','_'},  
                                            {'|', ' ','@',' ','|'},
                                            {'|', ' ',' ',' ','|'},
                                            {'/','\\',' ','/','\\'},
                                           };

        public static char[,] battleCrouser = {
                                                  {' ','\\', ' ','/',' '},
                                                  {' ',' ', '|',' ',' '},
                                                  {'[',']',' ','[',']'},
                                                  {'|',' ', '#',' ','|'},
                                                  {'|','_', '#','_','|'},
                                                  {' ',' ', 'V',' ',' '},
                                              };


        public static char[,] destroyer = {
                                              {'\\',' ','/'},
                                              {'@','|','@'},
                                              {'@','|','@'},
                                              {'=','V','='},
                                          };
                                             
    }
}
