using System.Drawing;

namespace TicTacToe.TicTacToeGame
{
    public class TicTacToeGameView : IDrawable
    {
        private ITicTacToeGame game;
        public float BoardScale { get; set; } = 0.0f;
        public float ElementScale { get; set; } = 0.0f;
        public float LineScale { get; set; } = 0.0f;

        public TicTacToeGameView(ITicTacToeGame game)
        {
            this.game = game;
        }
       
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.FillColor = Microsoft.Maui.Graphics.Color.FromRgb(0,0,0);
            DrawBoard(canvas,dirtyRect.Width,dirtyRect.Height);
            DrawPieces(canvas, dirtyRect.Width, dirtyRect.Height);
            DrawLine(canvas, dirtyRect.Width, dirtyRect.Height);
        }
        private void DrawLine(ICanvas canvas, float Width, float Height) 
        {
            var winInfo = game.GetWinInfo();
            if (winInfo == null) return;

            float startX = 0, startY = 0, endX = 0, endY = 0;

            switch (winInfo.Item2)
            {
                case WinType.Row:
                    startY = endY = (winInfo.Item1 + 0.5f) * Height / 3;
                    startX = 0;
                    endX = Width * LineScale;
                    break;

                case WinType.Column:
                    startX = endX = (winInfo.Item1 + 0.5f) * Width / 3;
                    startY = 0;
                    endY = Height * LineScale;
                    break;

                case WinType.Diagonal:
                    if (winInfo.Item1 != 0)
                    {
                        startX = 0;
                        startY = 0;
                        endX = Width * LineScale;
                        endY = Height * LineScale;
                    }
                    else
                    {
                        startX = 0;
                        startY = Height;
                        endX = Width * LineScale;
                        endY = Height*(1.0f-LineScale);
                    }
                    break;
            }



            canvas.StrokeColor = Microsoft.Maui.Graphics.Color.FromRgb(255, 0, 0);
            canvas.StrokeSize = 4;
            canvas.Alpha = 0.8f;
            canvas.SetShadow(new Microsoft.Maui.Graphics.SizeF(3, 3), 5, Colors.Black);
            canvas.DrawLine(startX, startY, endX, endY);

        }

        private void DrawBoard(ICanvas canvas, float Width, float Height)
        {
            for (int i = 1; i < 3; i++)
            {
                canvas.DrawLine(i * Width / 3, 0, i * Width / 3, Height*BoardScale);
                canvas.DrawLine(0, i * Height / 3, Width*BoardScale, i * Height / 3);
            }
        }

        private void DrawPieces(ICanvas canvas, float Width, float Height)
        {
            canvas.StrokeSize = 2;
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    var scale = 0.9f;
                    if (game.GetLastMove() == new Microsoft.Maui.Graphics.Point(row, col))
                    {
                        scale = ElementScale;
                    }
                    int piece = game.GetPiece(row, col);
                    if (piece == 1)
                    {
                        canvas.StrokeColor = Microsoft.Maui.Graphics.Color.FromRgb(0, 0, 0);
                        var centerX = (col + 0.5f) * Width / 3;
                        var centerY = (row + 0.5f) * Height / 3;
                        var halfWidth = Width / 6;
                        var halfHeight = Height / 6;

                        canvas.DrawLine(centerX - halfWidth * scale, centerY - halfHeight * scale, centerX + halfWidth * scale, centerY + halfHeight * scale);
                        canvas.DrawLine(centerX + halfWidth * scale, centerY - halfHeight * scale, centerX - halfWidth * scale, centerY + halfHeight * scale);
                    }
                    else if (piece == 2)
                    {
                        canvas.StrokeColor = Microsoft.Maui.Graphics.Color.FromRgb(0, 0, 0);
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
