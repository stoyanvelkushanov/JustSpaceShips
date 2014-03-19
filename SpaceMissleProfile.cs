using System;

namespace JustSpaceShips
{
    public static class SpaceMissleProfile
    {
        public static char[,] antMissle =  { {'^'},
                                             {'|'},
                                          };

        public static char[,] antMissleReverse =  { {'|'},
                                                    {'v'},
                                          };

        public static char[,] eagleMissle = { {'^','^'}, 
                                              {'|','|'}, 
                                              {'/','\\'},
                                            };

        public static char[,] eagleMissleReverse = { {'\\','/'}, 
                                                     {'|','|'}, 
                                                     {'v','v'},
                                            };

        public static char[,] superNova = {
                                              {' ','^',' '},
                                              {' ','^',' '},
                                              {'{',' ','}'},
                                              {'/',' ','\\'},
                                          };  

        public static char[,] superNovaReverse = {
                                              {'\\',' ','/'},
                                              {'(',' ',')'},
                                              {' ','v',' '},
                                              {' ','v',' '},
                                          };
    }
}

