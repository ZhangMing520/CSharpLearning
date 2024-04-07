using System;

namespace InterfaceExplicitImpl
{
    class InterfaceExplicitImpl
    {
        static void Main(string[] args)
        {
            FileView f = new FileView();
            f.Test();

            ((IFileHandler)f).Close();

            IWindow w = new FileView();
            w.Close();

            Console.ReadKey();
        }
    }

}


interface IWindow
{
    void Close();
}

interface IFileHandler
{
    void Close();
}


/// <summary>
/// 多个接口中存在同名方法，如何实现？
///
/// 1. 接口.方法名 指定实现
/// 2. 调用的时候，需要强制转换成具体接口
/// </summary>
class FileView : IWindow, IFileHandler
{
    /// <summary>
    /// 不能使用 public 修饰
    /// </summary>
    void IWindow.Close()
    {
        Console.WriteLine("Window Closed");
    }

    void IFileHandler.Close()
    {
        Console.WriteLine("File Closed");
    }

    public void Test()
    {
        ((IWindow)this).Close();
    }
}
