﻿//   - Blaster Master Class -
// Purpose:      Player's bullets
// Rev:          1.0
// Last updated: 22/03/10

using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace BlasterMaster
{
    public class clsPlayerMyBullet : clsPlayerBullet
    {
        bool m_Split;
        // Obj refs and instances
        private System.Drawing.Bitmap bullet;
        private ImageAttributes ImagingAtt = new ImageAttributes();

        public clsPlayerMyBullet(int x, int y,bool Split) : base(x, y)
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Class constructor  
            //------------------------------------------------------------------------------------------------------------------
            m_Split = Split;
            // Load resource image(s) & remove background and thu a sprite is born 
            bullet = BlasterMaster.Properties.Resources.playerBullet;
            bullet.MakeTransparent(Color.White);
        }

        public override void moveBullets(Graphics Destination)
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Method to move the player's bullets by 16 pixels every frame  
            //------------------------------------------------------------------------------------------------------------------

            // Scroll bullets
            base.setY(base.getY() - 15);
            if (m_Split == true)
            {
                base.setX(base.getX() + 4);
                
            }
            else
            {
                base.setX(base.getX() - 4);
            }
                
            // Sync collision rect
            base.setRectX(base.getX() + 2);
            base.setRectY(base.getY());
            base.setRectW(base.getW() - 5);
            base.setRectH(base.getH());

            // call to render
            this.Draw(Destination);
        }

        private void Draw(Graphics Destination)
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Method to render the player's sprite  
            //------------------------------------------------------------------------------------------------------------------

            // Draw sprite
            Destination.DrawImage(bullet, new Rectangle(base.getX(), base.getY(), base.getW(), base.getH()), 0, 0, base.getW(), base.getH(), GraphicsUnit.Pixel, ImagingAtt);
        }
    }
}

