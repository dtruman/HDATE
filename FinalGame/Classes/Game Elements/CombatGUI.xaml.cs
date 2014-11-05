using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

using FinalGame.Classes.Monster;
using FinalGame.Classes.Character;
namespace FinalGame.MapElements
{
    /// <summary>
    /// Interaction logic for CombatGUI.xaml
    /// </summary>
    public partial class CombatGUI : UserControl
    {

        Player p1;
        public Monster m1;
        int floorNumber;
        Image monsterImage;
        bool BossFloor;        Image fire;
        Image arrow;
        public CombatGUI(ref FinalGame.Classes.Character.Player p1, int floorNumber)
        {
            InitializeComponent();
            this.p1 = p1;
            this.floorNumber = floorNumber;
            BossFloor = floorNumber % 5 == 0;
            generateMonster();
            generateBack();
        }
        private void generateMonster()
        {
            BitmapImage imageSource = new BitmapImage();
            Random rand = new Random();
            int monsterChoice = rand.Next(0, 3);
            switch (monsterChoice)
            {
                case 0:
                    if (!BossFloor)
                        m1 = new DexMonster(floorNumber);
                    else
                        m1 = new Boss(floorNumber + 10);
                        m1.type = "dexMonster";
                    imageSource.BeginInit();
                    imageSource.UriSource = new Uri("/Resources/CombatEnemy_2.png", UriKind.Relative);
                    imageSource.EndInit();
                    break;
                case 1:
                    if (!BossFloor)
                        m1 = new IntMonster(floorNumber);
                    else
                        m1 = new Boss(floorNumber + 10);
                        m1.type = "intMonster";
                    imageSource.BeginInit();
                    imageSource.UriSource = new Uri("/Resources/CombatEnemy_1.png", UriKind.Relative);
                    imageSource.EndInit();
                    break;
                case 2:
                    if (!BossFloor)
                        m1 = new StrMonster(floorNumber);
                    else
                        m1 = new Boss(floorNumber + 10);
                        m1.type = "strMonster";
                    imageSource.BeginInit();
                    imageSource.UriSource = new Uri("/Resources/Orc.png", UriKind.Relative);
                    imageSource.EndInit();
                    break;
            }

            monsterImage = new Image();
            monsterImage.Source = imageSource;
            Monster.Children.Add(monsterImage);
            Hpbar.DataContext = m1;
        }
        public void generateBack()
        {
            BitmapImage imageSource = new BitmapImage();
            Random rand = new Random();
            int BackgroundChoice = rand.Next(0, 3);
            switch (BackgroundChoice)
            {
                case 0:
                    imageSource.BeginInit();
                    imageSource.UriSource = new Uri("Resources/cave2.jpg", UriKind.Relative);
                    imageSource.EndInit();
                    break;
                case 1:
                    imageSource.BeginInit();
                    imageSource.UriSource = new Uri("Resources/cavesecond.jpg", UriKind.Relative);
                    imageSource.EndInit();
                    break;
                case 2:
                    imageSource.BeginInit();
                    imageSource.UriSource = new Uri("Resources/cavefourth.jpg", UriKind.Relative);
                    imageSource.EndInit();
                    break;
            }
            backgroundbrush.ImageSource = imageSource;
        }
        private void AtkButton_Click(object sender, RoutedEventArgs e)
        {
            if (p1.EquippedWeapon != null && p1.EquippedWeapon.type == Classes.Items.WeaponType.Sword)
            {
                animatePlayerMove();
            }
            else if (p1.EquippedWeapon != null && p1.EquippedWeapon.type == Classes.Items.WeaponType.Staff)
            {
                animatePlayerMage();
            }
            else if (p1.EquippedWeapon != null && p1.EquippedWeapon.type == Classes.Items.WeaponType.Bow)
            {
                animatePlayerRanged();
            }
            else
            {
                animatePlayerMove();
            }
        }

        private void animateMonsterAttack()
        {
            if (m1.type == "strMonster")
                animateMonsterMove();
            if (m1.type == "intMonster")
                animateMonsterMage();
            if (m1.type == "dexMonster")
                animateMonsterRanged();
        }
        private void animatePlayerMove()
        {
            NameScope.SetNameScope(this, new NameScope());

            MatrixTransform buttonMatrixTransform = new MatrixTransform();
            PlayerGrid.RenderTransform = buttonMatrixTransform;

            this.RegisterName("PlayerMatrixTransform", buttonMatrixTransform);

            // Create the animation path.
            PathGeometry animationPath = new PathGeometry();
            PathFigure pFigure = new PathFigure();
            pFigure.StartPoint = new Point(0, 0);
            PolyBezierSegment pBezierSegment = new PolyBezierSegment();
            pBezierSegment.Points.Add(new Point(150, 0));
            pBezierSegment.Points.Add(new Point(175, 0));
            pBezierSegment.Points.Add(new Point(200, 0));
            pBezierSegment.Points.Add(new Point(225, 0));
            pFigure.Segments.Add(pBezierSegment);
            animationPath.Figures.Add(pFigure);

            // Freeze the PathGeometry for performance benefits.
            animationPath.Freeze();

            // Create a MatrixAnimationUsingPath to move the 
            // button along the path by animating 
            // its MatrixTransform.
            MatrixAnimationUsingPath matrixAnimation =
                new MatrixAnimationUsingPath();
            matrixAnimation.PathGeometry = animationPath;
            matrixAnimation.Duration = TimeSpan.FromSeconds(1);
            matrixAnimation.AutoReverse = true;

            // Set the animation to target the Matrix property 
            // of the MatrixTransform named "ButtonMatrixTransform".
            Storyboard.SetTargetName(matrixAnimation, "PlayerMatrixTransform");
            Storyboard.SetTargetProperty(matrixAnimation,
                new PropertyPath(MatrixTransform.MatrixProperty));

            // Create a Storyboard to contain and apply the animation.
            Storyboard pathAnimationStoryboard = new Storyboard();
            pathAnimationStoryboard.Children.Add(matrixAnimation);

            pathAnimationStoryboard.Completed += pathAnimationStoryboardPAttack_Completed;
            // Start the storyboard.
            AtkButton.IsEnabled = false;
            pathAnimationStoryboard.Begin(this);
        }
        private void animateMonsterMove()
        {

            NameScope.SetNameScope(this, new NameScope());

            MatrixTransform buttonMatrixTransform = new MatrixTransform();
            Monster.RenderTransform = buttonMatrixTransform;

            this.RegisterName("PlayerMatrixTransform", buttonMatrixTransform);

            // Create the animation path.
            PathGeometry animationPath = new PathGeometry();
            PathFigure pFigure = new PathFigure();
            pFigure.StartPoint = new Point(0, 0);
            PolyBezierSegment pBezierSegment = new PolyBezierSegment();
            pBezierSegment.Points.Add(new Point(-500, 0));
            pBezierSegment.Points.Add(new Point(-175, 0));
            pBezierSegment.Points.Add(new Point(-175, 0));
            pBezierSegment.Points.Add(new Point(-500, 0));
            pFigure.Segments.Add(pBezierSegment);
            animationPath.Figures.Add(pFigure);

            // Freeze the PathGeometry for performance benefits.
            animationPath.Freeze();

            // Create a MatrixAnimationUsingPath to move the 
            // button along the path by animating 
            // its MatrixTransform.
            MatrixAnimationUsingPath matrixAnimation =
                new MatrixAnimationUsingPath();
            matrixAnimation.PathGeometry = animationPath;
            matrixAnimation.Duration = TimeSpan.FromSeconds(1);
            matrixAnimation.AutoReverse = true;

            // Set the animation to target the Matrix property 
            // of the MatrixTransform named "ButtonMatrixTransform".
            Storyboard.SetTargetName(matrixAnimation, "PlayerMatrixTransform");
            Storyboard.SetTargetProperty(matrixAnimation,
                new PropertyPath(MatrixTransform.MatrixProperty));

            // Create a Storyboard to contain and apply the animation.
            Storyboard pathAnimationStoryboard = new Storyboard();
            pathAnimationStoryboard.Children.Add(matrixAnimation);

            pathAnimationStoryboard.Completed += pathAnimationStoryboardMMove_Completed;
            // Start the storyboard.
            pathAnimationStoryboard.Begin(this);
        }
        private void animateMonsterMage()
        {
            BitmapImage fireSource = new BitmapImage();

            fireSource.BeginInit();
            fireSource.UriSource = new Uri("/Resources/Fire Front.png", UriKind.Relative);
            fireSource.EndInit();
            fire = new Image();
            fire.Source = fireSource;

            PlayerGrid.Children.Add(fire);

            NameScope.SetNameScope(this, new NameScope());

            MatrixTransform buttonMatrixTransform = new MatrixTransform();
            fire.RenderTransform = buttonMatrixTransform;

            this.RegisterName("FireMatrixTransform", buttonMatrixTransform);

            // Create the animation path.
            PathGeometry animationPath = new PathGeometry();
            PathFigure pFigure = new PathFigure();
            pFigure.StartPoint = new Point(0, 20);
            PolyBezierSegment pBezierSegment = new PolyBezierSegment();
            pBezierSegment.Points.Add(new Point(0, 20));
            pBezierSegment.Points.Add(new Point(0, 5));
            pBezierSegment.Points.Add(new Point(0, 15));
            pBezierSegment.Points.Add(new Point(0, 20));
            pFigure.Segments.Add(pBezierSegment);
            animationPath.Figures.Add(pFigure);

            // Freeze the PathGeometry for performance benefits.
            animationPath.Freeze();

            // Create a MatrixAnimationUsingPath to move the 
            // button along the path by animating 
            // its MatrixTransform.
            MatrixAnimationUsingPath matrixAnimation =
                new MatrixAnimationUsingPath();
            matrixAnimation.PathGeometry = animationPath;
            matrixAnimation.Duration = TimeSpan.FromSeconds(.5);
            matrixAnimation.AutoReverse = true;

            // Set the animation to target the Matrix property 
            // of the MatrixTransform named "ButtonMatrixTransform".
            Storyboard.SetTargetName(matrixAnimation, "FireMatrixTransform");
            Storyboard.SetTargetProperty(matrixAnimation,
                new PropertyPath(MatrixTransform.MatrixProperty));

            // Create a Storyboard to contain and apply the animation.
            Storyboard pathAnimationStoryboard = new Storyboard();
            pathAnimationStoryboard.Children.Add(matrixAnimation);

            pathAnimationStoryboard.Completed += pathAnimationStoryboardFireMonster_Completed;
            // Start the storyboard.
            //AtkButton.IsEnabled = false;
            pathAnimationStoryboard.Begin(this);
        }
        private void animateMonsterRanged()
        {
            BitmapImage arrowSource = new BitmapImage();

            arrowSource.BeginInit();
            arrowSource.UriSource = new Uri("/Resources/MArrow_25x16_Trans.png", UriKind.Relative);
            arrowSource.EndInit();
            arrow = new Image();
            arrow.Source = arrowSource;

            MArrowGrid.Children.Add(arrow);

            NameScope.SetNameScope(this, new NameScope());

            MatrixTransform buttonMatrixTransform = new MatrixTransform();
            MArrowGrid.RenderTransform = buttonMatrixTransform;

            this.RegisterName("FireMatrixTransform", buttonMatrixTransform);

            // Create the animation path.
            PathGeometry animationPath = new PathGeometry();
            PathFigure pFigure = new PathFigure();
            pFigure.StartPoint = new Point(0, 0);
            PolyBezierSegment pBezierSegment = new PolyBezierSegment();
            pBezierSegment.Points.Add(new Point(-150,0));
            pBezierSegment.Points.Add(new Point(-175,0));
            pBezierSegment.Points.Add(new Point(-200,0));
            pBezierSegment.Points.Add(new Point(-250,0));
            pFigure.Segments.Add(pBezierSegment);
            animationPath.Figures.Add(pFigure);

            // Freeze the PathGeometry for performance benefits.
            animationPath.Freeze();

            // Create a MatrixAnimationUsingPath to move the 
            // button along the path by animating 
            // its MatrixTransform.
            MatrixAnimationUsingPath matrixAnimation =
                new MatrixAnimationUsingPath();
            matrixAnimation.PathGeometry = animationPath;
            matrixAnimation.Duration = TimeSpan.FromSeconds(.5);

            // Set the animation to target the Matrix property 
            // of the MatrixTransform named "ButtonMatrixTransform".
            Storyboard.SetTargetName(matrixAnimation, "FireMatrixTransform");
            Storyboard.SetTargetProperty(matrixAnimation,
                new PropertyPath(MatrixTransform.MatrixProperty));

            // Create a Storyboard to contain and apply the animation.
            Storyboard pathAnimationStoryboard = new Storyboard();
            pathAnimationStoryboard.Children.Add(matrixAnimation);

            pathAnimationStoryboard.Completed += pathAnimationStoryboardMRangedMove_Completed;
            // Start the storyboard.
            //AtkButton.IsEnabled = false;
            pathAnimationStoryboard.Begin(this);

        }
        private void animatePlayerMage()
        {

            BitmapImage fireSource = new BitmapImage();

            fireSource.BeginInit();
            fireSource.UriSource = new Uri("/Resources/Fire Front.png", UriKind.Relative);
            fireSource.EndInit();
            fire = new Image();
            fire.Source = fireSource;

            Monster.Children.Add(fire);

            NameScope.SetNameScope(this, new NameScope());

            MatrixTransform buttonMatrixTransform = new MatrixTransform();
            fire.RenderTransform = buttonMatrixTransform;

            this.RegisterName("FireMatrixTransform", buttonMatrixTransform);

            // Create the animation path.
            PathGeometry animationPath = new PathGeometry();
            PathFigure pFigure = new PathFigure();
            pFigure.StartPoint = new Point(0, 20);
            PolyBezierSegment pBezierSegment = new PolyBezierSegment();
            pBezierSegment.Points.Add(new Point(0, 20));
            pBezierSegment.Points.Add(new Point(0, 5));
            pBezierSegment.Points.Add(new Point(0, 15));
            pBezierSegment.Points.Add(new Point(0, 20));
            pFigure.Segments.Add(pBezierSegment);
            animationPath.Figures.Add(pFigure);

            // Freeze the PathGeometry for performance benefits.
            animationPath.Freeze();

            // Create a MatrixAnimationUsingPath to move the 
            // button along the path by animating 
            // its MatrixTransform.
            MatrixAnimationUsingPath matrixAnimation =
                new MatrixAnimationUsingPath();
            matrixAnimation.PathGeometry = animationPath;
            matrixAnimation.Duration = TimeSpan.FromSeconds(.5);
            matrixAnimation.AutoReverse = true;

            // Set the animation to target the Matrix property 
            // of the MatrixTransform named "ButtonMatrixTransform".
            Storyboard.SetTargetName(matrixAnimation, "FireMatrixTransform");
            Storyboard.SetTargetProperty(matrixAnimation,
                new PropertyPath(MatrixTransform.MatrixProperty));

            // Create a Storyboard to contain and apply the animation.
            Storyboard pathAnimationStoryboard = new Storyboard();
            pathAnimationStoryboard.Children.Add(matrixAnimation);

            pathAnimationStoryboard.Completed += pathAnimationStoryboardFireMove_Completed;
            // Start the storyboard.
            AtkButton.IsEnabled = false;
            pathAnimationStoryboard.Begin(this);

        }
        private void animatePlayerRanged()
        {
            BitmapImage arrowSource = new BitmapImage();

            arrowSource.BeginInit();
            arrowSource.UriSource = new Uri("/Resources/PArrow_25x16_Trans.png", UriKind.Relative);
            arrowSource.EndInit();
            arrow = new Image();
            arrow.Source = arrowSource;

            PArrowGrid.Children.Add(arrow);

            NameScope.SetNameScope(this, new NameScope());

            MatrixTransform buttonMatrixTransform = new MatrixTransform();
            PArrowGrid.RenderTransform = buttonMatrixTransform;

            this.RegisterName("FireMatrixTransform", buttonMatrixTransform);

            // Create the animation path.
            PathGeometry animationPath = new PathGeometry();
            PathFigure pFigure = new PathFigure();
            pFigure.StartPoint = new Point(0, 0);
            PolyBezierSegment pBezierSegment = new PolyBezierSegment();
            pBezierSegment.Points.Add(new Point(150,0));
            pBezierSegment.Points.Add(new Point(175,0));
            pBezierSegment.Points.Add(new Point(200,0));
            pBezierSegment.Points.Add(new Point(225,0));
            pFigure.Segments.Add(pBezierSegment);
            animationPath.Figures.Add(pFigure);

            // Freeze the PathGeometry for performance benefits.
            animationPath.Freeze();

            // Create a MatrixAnimationUsingPath to move the 
            // button along the path by animating 
            // its MatrixTransform.
            MatrixAnimationUsingPath matrixAnimation =
                new MatrixAnimationUsingPath();
            matrixAnimation.PathGeometry = animationPath;
            matrixAnimation.Duration = TimeSpan.FromSeconds(.5);

            // Set the animation to target the Matrix property 
            // of the MatrixTransform named "ButtonMatrixTransform".
            Storyboard.SetTargetName(matrixAnimation, "FireMatrixTransform");
            Storyboard.SetTargetProperty(matrixAnimation,
                new PropertyPath(MatrixTransform.MatrixProperty));

            // Create a Storyboard to contain and apply the animation.
            Storyboard pathAnimationStoryboard = new Storyboard();
            pathAnimationStoryboard.Children.Add(matrixAnimation);

            pathAnimationStoryboard.Completed += pathAnimationStoryboardRangedMove_Completed;
            // Start the storyboard.
            AtkButton.IsEnabled = false;
            pathAnimationStoryboard.Begin(this);
        }

        private void pathAnimationStoryboardPAttack_Completed(object sender, EventArgs e)
        {

            animateMonsterAttack();
        }
        private void pathAnimationStoryboardMMove_Completed(object sender, EventArgs e)
        {
            AtkButton.IsEnabled = true;
        }
        private void pathAnimationStoryboardFireMove_Completed(object sender, EventArgs e)
        {
            Monster.Children.Remove(fire);
            animateMonsterAttack();
        }
        private void pathAnimationStoryboardFireMonster_Completed(object sender, EventArgs e)
        {
            PlayerGrid.Children.Remove(fire);
            AtkButton.IsEnabled = true;
        }
        private void pathAnimationStoryboardMRangedMove_Completed(object sender, EventArgs e)
        {
            MArrowGrid.Children.Remove(arrow);
            AtkButton.IsEnabled = true;
        }
        private void pathAnimationStoryboardRangedMove_Completed(object sender, EventArgs e)
        {
            PArrowGrid.Children.Remove(arrow);
            animateMonsterAttack();
        }
    }
}
