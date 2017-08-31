using System;

namespace Sparrow {
	public class ModelBase: IDisposable {
		protected bool isDisposed = false;

		~ModelBase(){
			Dispose();
		}
		
		public virtual void Dispose(){
			if(!isDisposed){
				isDisposed = true;

			}
		}
	}
}