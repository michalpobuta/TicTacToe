using System.Drawing;

namespace TicTacToe.TicTacToeGame
{
    public class TicTacToeGameView : IDrawable
    {
        private ITicTacToeGame game;
        public float BoardScale { get; set; } = 0.0f;
        public float ElementScale { get; set; } = 0.0f;

        public TicTacToeGameView(ITicTacToeGame game)
        {
            this.game = game;
        }
       
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.FillColor = Microsoft.Maui.Graphics.Color.FromRgb(0,0,0);
            // Draw the game board and pieces...
            DrawBoard(canvas,dirtyRect.Width,dirtyRect.Height);
            DrawPieces(canvas, dirtyRect.Width, dirtyRect.Height);
        }

        private void DrawBoard(ICanvas canvas, float Width, float Height)
        {
            //canvas.Rotate(360*BoardScale);
            //canvas.Scale(BoardScale, BoardScale);
            for (int i = 1; i < 3; i++)
            {
                
                // Vertical lines
                canvas.DrawLine(i * Width / 3, 0, i * Width / 3, Height*BoardScale);

                // Horizontal lines
                canvas.DrawLine(0, i * Height / 3, Width*BoardScale, i * Height / 3);
            }
        }

        private void DrawPieces(ICanvas canvas, float Width, float Height)
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    var scale = 1.0f;
                    if (game.GetLastMove() == new Microsoft.Maui.Graphics.Point(row, col))
                    {
                        scale = ElementScale;
                    }
                    int piece = game.GetPiece(row, col);
                    if (piece == 1)
                    {
                        canvas.StrokeColor = Microsoft.Maui.Graphics.Color.FromRgb(255, 0, 0);
                        // Draw X
                        var centerX = (col + 0.5f) * Width / 3;
                        var centerY = (row + 0.5f) * Height / 3;
                        var halfWidth = Width / 6;
                        var halfHeight = Height / 6;

                        canvas.DrawLine(centerX - halfWidth * scale, centerY - halfHeight * scale, centerX + halfWidth * scale, centerY + halfHeight * scale);
                        canvas.DrawLine(centerX + halfWidth * scale, centerY - halfHeight * scale, centerX - halfWidth * scale, centerY + halfHeight * scale);
                    }
                    else if (piece == 2)
                    {
                        canvas.StrokeColor = Microsoft.Maui.Graphics.Color.FromRgb(0, 0, 255);
                        // Draw O
                        var centerX = (col + 0.5f) * Width / 3;
                        var centerY = (row + 0.5f) * Height / 3;

                        canvas.DrawEllipse(centerX - (Width / 6) * scale, centerY - (Height / 6) * scale, (Width / 3) * scale, (Height / 3) * scale);
                    }
                    canvas.StrokeColor = Microsoft.Maui.Graphics.Color.FromRgb(0, 0, 0);
                }
            }
        }
    }
}
