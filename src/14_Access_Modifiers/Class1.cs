namespace _14_Access_Modifiers
{
    public class Class1
    {
        public void X()
        {

        }

        protected void Y()
        { 
        }

        void Z() // default olarak private
        {
            Y();
        }

        internal void Q() // aynı proje haricinde erişilemez
        {
            
        }

        private protected void W()
        {

        }
    }

    class Class2 : Class1
    {
        public Class2()
        {
            Class1 c = new();
            // c.Y(); // protected, instance üzerinden erişimi engellediği için kullanılamaz!
            base.Y(); // class üzerinden erişimi ise mümkün kılar. base'den gelir (keyword'e gerek yok)

            W(); // class üzerinden erişim, protected olduğu için mümkündür.
        }
    }
}
