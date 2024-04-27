using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinningsCalculator
{
    
    public class WinningsCalculator
    {
        public WinningsCalculator() { }
        public WinType[] findWins(PictureMap[,] pictureMatrix, WinType[] winType)
        {
            for(int l = 0; l < winType.Length; ++l)
            {
                winType[l] = null;
            }
            int c = 0;
            int i;
            for (i = 0; i < 3; ++i)
            {  //linii
                if (pictureMatrix[i, 0].equalsTo(pictureMatrix[i, 1]) && pictureMatrix[i, 0].equalsTo(pictureMatrix[i, 2]) && pictureMatrix[i, 0].equalsTo(pictureMatrix[i, 3]) && pictureMatrix[i, 0].equalsTo(pictureMatrix[i, 4]))
                {
                    //win primele 5
                    if (i == 0)
                    {
                        winType[c] = new WinType("red", calculateWinningAmount(pictureMatrix[i, 0], 5), 5);
                        ++c;
                    }
                    else if (i == 1)
                    {
                        winType[c] = new WinType("blue", calculateWinningAmount(pictureMatrix[i, 0], 5), 5);
                        ++c;
                    }
                    else if (i == 2)
                    {
                        winType[c] = new WinType("green", calculateWinningAmount(pictureMatrix[i, 0], 5), 5);
                        ++c;
                    }
                }
                else if (pictureMatrix[i, 0].equalsTo(pictureMatrix[i, 1]) && pictureMatrix[i, 0].equalsTo(pictureMatrix[i, 2]) && pictureMatrix[i, 0].equalsTo(pictureMatrix[i, 3]))
                {
                    //win primele 4
                    if (i == 0)
                    {
                        winType[c] = new WinType("red", calculateWinningAmount(pictureMatrix[i, 0], 4), 4);
                        ++c;
                    }
                    else if (i == 1)
                    {
                        winType[c] = new WinType("blue", calculateWinningAmount(pictureMatrix[i, 0], 4), 4);
                        ++c;
                    }
                    else if (i == 2)
                    {
                        winType[c] = new WinType("green", calculateWinningAmount(pictureMatrix[i, 0], 4), 4);
                        ++c;
                    }
                }
                else if (pictureMatrix[i, 0].equalsTo(pictureMatrix[i, 1]) && pictureMatrix[i, 0].equalsTo(pictureMatrix[i, 2]))
                {
                    //win primele 3
                    if (i == 0)
                    {
                        winType[c] = new WinType("red", calculateWinningAmount(pictureMatrix[i, 0], 3), 3);
                        ++c;
                    }
                    else if (i == 1)
                    {
                        winType[c] = new WinType("blue", calculateWinningAmount(pictureMatrix[i, 0], 3), 3);
                        ++c;
                    }
                    else if (i == 2)
                    {
                        winType[c] = new WinType("green", calculateWinningAmount(pictureMatrix[i, 0], 3), 3);
                        ++c;
                    }
                }
                else if (pictureMatrix[i, 0].equalsTo(pictureMatrix[i, 1]) && pictureMatrix[i, 0].ImageId == "cherry")
                {
                    if (i == 0) {
                        winType[c] = new WinType("red", calculateWinningAmount(pictureMatrix[i, 0], 2), 2);
                        ++c;
                    }
                    else if (i == 1) {
                        winType[c] = new WinType("blue", calculateWinningAmount(pictureMatrix[i, 0], 2), 2);
                        ++c;
                    }
                    else if (i == 2) {
                        winType[c] = new WinType("green", calculateWinningAmount(pictureMatrix[i, 0], 2), 2);
                        ++c;
                    }
                }
            }
           
            if (pictureMatrix[2, 0].equalsTo(pictureMatrix[1, 1]) && pictureMatrix[1, 1].equalsTo(pictureMatrix[0, 2])&&pictureMatrix[0,2].equalsTo(pictureMatrix[1,3])&&pictureMatrix[1,3].equalsTo(pictureMatrix[2,4])) {  
                winType[c] = new WinType("purple", calculateWinningAmount(pictureMatrix[2, 0], 5), 5);
                ++c;
            }
            else if (pictureMatrix[2, 0].equalsTo(pictureMatrix[1, 1]) && pictureMatrix[1, 1].equalsTo(pictureMatrix[0, 2]) && pictureMatrix[0, 2].equalsTo(pictureMatrix[1, 3]))
            {
                winType[c] = new WinType("purple", calculateWinningAmount(pictureMatrix[2, 0], 4), 4);
                ++c;
            }
            else if(pictureMatrix[2, 0].equalsTo(pictureMatrix[1, 1]) && pictureMatrix[1, 1].equalsTo(pictureMatrix[0, 2]))
            {
                winType[c] = new WinType("purple", calculateWinningAmount(pictureMatrix[2, 0], 3),3);
                ++c;
            }
            else if (pictureMatrix[2, 0].equalsTo(pictureMatrix[1, 1]) && pictureMatrix[2, 0].ImageId == "cherry")
            {
                winType[c] = new WinType("purple", calculateWinningAmount(pictureMatrix[2, 0], 2),2);
                ++c;
            }
        

            if (pictureMatrix[0, 0].equalsTo(pictureMatrix[1, 1]) && pictureMatrix[1, 1].equalsTo(pictureMatrix[2, 2])&&pictureMatrix[2,2].equalsTo(pictureMatrix[1,3])&&pictureMatrix[1,3].equalsTo(pictureMatrix[0,4])) {  //jumate de diagonala
                //piramida
                winType[c] = new WinType("yellow", calculateWinningAmount(pictureMatrix[0, 0], 5), 5);
                ++c;
            }

            else if (pictureMatrix[0, 0].equalsTo(pictureMatrix[1, 1]) && pictureMatrix[1, 1].equalsTo(pictureMatrix[2, 2]) && pictureMatrix[2, 2].equalsTo(pictureMatrix[1, 3]))
            {
                winType[c] = new WinType("yellow", calculateWinningAmount(pictureMatrix[0, 0], 4), 4);
                ++c;
            }
            else if(pictureMatrix[0, 0].equalsTo(pictureMatrix[1, 1]) && pictureMatrix[1, 1].equalsTo(pictureMatrix[2, 2]))
            {
                winType[c] = new WinType("yellow", calculateWinningAmount(pictureMatrix[0, 0], 3),3);
                ++c;
            }
            else if (pictureMatrix[0, 0].equalsTo(pictureMatrix[1, 1]) && pictureMatrix[0, 0].ImageId == "cherry")
            {
                winType[c] = new WinType("yellow", calculateWinningAmount(pictureMatrix[0, 0], 2),2);
                ++c;
            }


            int starCounter = 0;
            int line=0, column=0;
            for(int l=0; l < 3; ++l){
               for(int j = 0; j < 5; ++j){
                   if(pictureMatrix[l,j].ImageId == "star"){
                       starCounter++;
                       line=l;
                       column=j;
                   }
               }
           }

            if(starCounter==3){
                winType[c] = new WinType("star", calculateWinningAmount(pictureMatrix[line,column], 3),3);
                ++c;
            }else if(starCounter==4){
                winType[c] = new WinType("star", calculateWinningAmount(pictureMatrix[line,column], 4),4);
                ++c;
            }else if(starCounter==5){
                winType[c] = new WinType("star", calculateWinningAmount(pictureMatrix[line,column], 5),5);
                ++c;
            }
            return winType;
        }

        private double calculateWinningAmount(PictureMap picture, int amount)
        {
            String id = picture.ImageId;
            switch (id)
            {
                case "cherry":
                    switch (amount)
                    {
                        case 2:
                            return 0.4;
                        case 3:
                            return 1.6;
                        case 4:
                            return 4;
                        case 5:
                            return 16;
                    }
                    break;
                
                case "orange":
                    switch (amount)
                    {
                        case 3:
                            return 1.6;
                        case 4:
                            return 4;
                        case 5:
                            return 16;
                    }
                    break;
               
                case "lemon":
                    switch (amount)
                    {
                        case 3:
                            return 1.6;
                        case 4:
                            return 4;
                        case 5:
                            return 16;
                    }
                    break;
                
                case "plum":
                    switch (amount)
                    {
                        case 3:
                            return 1.6;
                        case 4:
                            return 4;
                        case 5:
                            return 16;
                    }
                    break;
                
                case "grapes":
                    switch (amount)
                    {
                        case 3:
                            return 4;
                        case 4:
                            return 16;
                        case 5:
                            return 40;
                    }
                    break;
               
                case "watermelon":
                    switch (amount)
                    {
                        case 3:
                            return 4;
                        case 4:
                            return 16;
                        case 5:
                            return 40;
                    }
                    break;
                
                case "star":
                    switch (amount) {
                        case 3:
                            return 0.8;
                        case 4:
                            return 4;
                        case 5:
                            return 20;
                    }
                    break;
               
                case "seven":
                    switch (amount) {
                        case 3:
                            return 8;
                        case 4:
                            return 80;
                        case 5:
                            return 400;
                    }
                    break;

                default:
                    return 0;
            }
            return 0;
        }
    }
}
