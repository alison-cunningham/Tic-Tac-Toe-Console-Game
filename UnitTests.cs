using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace TicTacToe
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void NoWinX()
        {
            try
            {
                char[,] board = {   { '1', '2', '3' }, 
                                    { '4', '5', '6' }, 
                                    { '7', '8', '9' }   };

                Assert.IsFalse(TicTacToe.CheckWin(board, 'X'));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void NoWinO()
        {
            try
            {
                char[,] board = {   { '1', '2', '3' },
                                    { '4', '5', '6' },
                                    { '7', '8', '9' }   };

                Assert.IsFalse(TicTacToe.CheckWin(board, 'O'));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void WinXVertical1()
        {
            try
            {
                char[,] board = {   { 'X', '2', 'O' },
                                    { 'X', 'O', '6' },
                                    { 'X', '8', '9' }   };

                Assert.IsTrue(TicTacToe.CheckWin(board, 'X'));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void WinXVertical2()
        {
            try
            {
                char[,] board = {   { '1', 'X', '3' },
                                    { 'O', 'X', '6' },
                                    { 'O', 'X', '9' }   };

                Assert.IsTrue(TicTacToe.CheckWin(board, 'X'));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void WinXVertical3()
        {
            try
            {
                char[,] board = {   { '1', '2', 'X' },
                                    { '4', '5', 'X' },
                                    { 'O', 'O', 'X' }   };

                Assert.IsTrue(TicTacToe.CheckWin(board, 'X'));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void WinXHorizontal1()
        {
            try
            {
                char[,] board = {   { 'X', 'X', 'X' },
                                    { '4', '5', '6' },
                                    { 'O', 'O', '9' }   };

                Assert.IsTrue(TicTacToe.CheckWin(board, 'X'));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void WinXHorizontal2()
        {
            try
            {
                char[,] board = {   { '1', 'O', '3' },
                                    { 'X', 'X', 'X' },
                                    { 'O', '8', '9' }   };

                Assert.IsTrue(TicTacToe.CheckWin(board, 'X'));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void WinXHorizontal3()
        {
            try
            {
                char[,] board = {   { '1', 'O', '3' },
                                    { '4', 'O', '6' },
                                    { 'X', 'X', 'X' }   };

                Assert.IsTrue(TicTacToe.CheckWin(board, 'X'));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void WinXDiagonal1()
        {
            try
            {
                char[,] board = {   { 'X', 'O', '3' },
                                    { '4', 'X', '6' },
                                    { '7', 'O', 'X' }   };

                Assert.IsTrue(TicTacToe.CheckWin(board, 'X'));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void WinXDiagonal2()
        {
            try
            {
                char[,] board = {   { '1', 'O', 'X' },
                                    { 'O', 'X', '6' },
                                    { 'X', '8', '9' }   };

                Assert.IsTrue(TicTacToe.CheckWin(board, 'X'));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        //START Tests for player o


        [TestMethod]
        public void WinOVertical1False()
        {
            try
            {
                char[,] board = {   { 'O', '2', '3' },
                                    { 'O', '5', 'X' },
                                    { 'O', '8', 'X' }   };

                Assert.IsFalse(TicTacToe.CheckWin(board, 'X'));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void WinOVertical1()
        {
            try
            {
                char[,] board = {   { 'O', '2', '3' },
                                    { 'O', '5', 'X' },
                                    { 'O', 'X', '9' }   };

                Assert.IsTrue(TicTacToe.CheckWin(board, 'O'));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void WinOVertical2()
        {
            try
            {
                char[,] board = {   { '1', 'O', '3' },
                                    { 'X', 'O', '6' },
                                    { 'X', 'O', '9' }   };

                Assert.IsTrue(TicTacToe.CheckWin(board, 'O'));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void WinOVertical2False()
        {
            try
            {
                char[,] board = {   { '1', 'O', '3' },
                                    { 'X', 'O', '6' },
                                    { 'X', 'O', '9' }   };

                Assert.IsFalse(TicTacToe.CheckWin(board, 'X'));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void WinOVertical3()
        {
            try
            {
                char[,] board = {   { '1', '2', 'O' },
                                    { '4', '5', 'O' },
                                    { 'X', 'X', 'O' }   };

                Assert.IsTrue(TicTacToe.CheckWin(board, 'O'));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void WinOVertical3False()
        {
            try
            {
                char[,] board = {   { '1', '2', 'O' },
                                    { '4', '5', 'O' },
                                    { 'X', 'X', 'O' }   };

                Assert.IsFalse(TicTacToe.CheckWin(board, 'X'));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void WinOHorizontal1()
        {
            try
            {
                char[,] board = {   { 'O', 'O', 'O' },
                                    { '4', '5', '6' },
                                    { 'X', 'X', '9' }   };

                Assert.IsTrue(TicTacToe.CheckWin(board, 'O'));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void WinOHorizontal1False()
        {
            try
            {
                char[,] board = {   { 'O', 'O', 'O' },
                                    { '4', '5', '6' },
                                    { 'X', 'X', '9' }   };

                Assert.IsFalse(TicTacToe.CheckWin(board, 'X'));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void WinOHorizontal2()
        {
            try
            {
                char[,] board = {   { '1', 'X', '3' },
                                    { 'O', 'O', 'O' },
                                    { 'X', '8', '9' }   };

                Assert.IsTrue(TicTacToe.CheckWin(board, 'O'));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void WinOHorizontal2fALSE()
        {
            try
            {
                char[,] board = {   { '1', 'X', '3' },
                                    { 'O', 'O', 'O' },
                                    { 'X', '8', '9' }   };

                Assert.IsFalse(TicTacToe.CheckWin(board, 'X'));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void WinOHorizontal3()
        {
            try
            {
                char[,] board = {   { '1', 'X', '3' },
                                    { '4', 'X', '6' },
                                    { 'O', 'O', 'O' }   };

                Assert.IsTrue(TicTacToe.CheckWin(board, 'O'));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void WinOHorizontal3False()
        {
            try
            {
                char[,] board = {   { '1', 'X', '3' },
                                    { '4', 'X', '6' },
                                    { 'O', 'O', 'O' }   };

                Assert.IsFalse(TicTacToe.CheckWin(board, 'X'));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }


        [TestMethod]
        public void WinODiagonal1()
        {
            try
            {
                char[,] board = {   { 'O', '2', '3' },
                                    { '4', 'O', '6' },
                                    { 'X', 'X', 'O' }   };

                Assert.IsTrue(TicTacToe.CheckWin(board, 'O'));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void WinODiagonal1False()
        {
            try
            {
                char[,] board = {   { 'O', '2', '3' },
                                    { '4', 'O', '6' },
                                    { 'X', 'X', 'O' }   };

                Assert.IsFalse(TicTacToe.CheckWin(board, 'X'));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void WinODiagonal2()
        {
            try
            {
                char[,] board = {   { '1', '2', 'O' },
                                    { 'X', 'O', 'X' },
                                    { 'O', '8', '9' }   };

                Assert.IsTrue(TicTacToe.CheckWin(board, 'O'));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void WinODiagonal2False()
        {
            try
            {
                char[,] board = {   { '1', '2', 'O' },
                                    { 'X', 'O', 'X' },
                                    { 'O', '8', '9' }   };

                Assert.IsFalse(TicTacToe.CheckWin(board, 'X'));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void Tie1X()
        {
            try
            {
                char[,] board = {   { 'X', 'O', 'X' },
                                    { 'X', 'O', 'O' },
                                    { 'O', 'X', 'O' }   };

                Assert.IsFalse(TicTacToe.CheckWin(board, 'X'));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void Tie1O()
        {
            try
            {
                char[,] board = {   { 'X', 'O', 'X' },
                                    { 'X', 'O', 'O' },
                                    { 'O', 'X', 'O' }   };

                Assert.IsFalse(TicTacToe.CheckWin(board, 'O'));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void Tie2O()
        {
            try
            {
                char[,] board = {   { 'X', 'O', 'X' },
                                    { 'X', 'X', 'O' },
                                    { 'O', 'X', 'O' }   };

                Assert.IsFalse(TicTacToe.CheckWin(board, 'O'));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void Tie2X()
        {
            try
            {
                char[,] board = {   { 'X', 'O', 'X' },
                                    { 'X', 'X', 'O' },
                                    { 'O', 'X', 'O' }   };

                Assert.IsFalse(TicTacToe.CheckWin(board, 'X'));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

    }
}
