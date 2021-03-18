using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Result
{
    public interface IResult
    {
        //Temel Voidler için başlangıç 
        // Public Yaptık İçerisinde işlem sonucu ve Kullanıcı bilgilendirme mesajı olacak
        bool Succes { get; }   //Succes Bool Başaralı mı başarısız mı
        string Message { get; }         // Bilgilendirme Succes doğru mu değil mi

    }
}
