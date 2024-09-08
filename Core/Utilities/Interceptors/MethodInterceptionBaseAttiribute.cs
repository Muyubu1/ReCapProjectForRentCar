using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor    //DynamicProxydne gelen yapıyı kullanıyoruz
    {
        public int Priority { get; set; } // birden fazla çağrıldığında öncelik sırası belirlemek için kullanılır


        //kesme işlemi yapılacak metot programdan önce veya sonra çalıştırılacak
        public virtual void Intercept(IInvocation invocation)
        {

        }
    }

}

