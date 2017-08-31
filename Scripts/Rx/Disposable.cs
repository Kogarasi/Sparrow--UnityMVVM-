using System;

namespace Sparrow.Rx {
	public class Disposable: IDisposable  {
		bool isDisposed = false;

		public virtual void dispose(){}

		~Disposable(){
			Dispose();
		}
		
		public virtual void Dispose(){
			if(!isDisposed){
				isDisposed = true;

			}
		}
	}
}