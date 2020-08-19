export class BaseTransformer {
    constructor() {
      this.transform = this.transform.bind(this);
      this.transformSingle = this.transformSingle.bind(this);
      this.transformMultiple = this.transformMultiple.bind(this);
    }
  
    transform(payload) {
      const data = payload;
      let result = {};
  
      if (data) {
        if ((Array.isArray(data) || data.length)) {
          result = this.transformMultiple(data);
        } else {
          result = this.transformSingle(data);
        }
      }
  
      return result;
    }
  
    transformSingle() {
      throw new Error('You have to implement the method transformSingle!');
    }
  
    transformMultiple() {
      throw new Error('You have to implement the method transformMultiple!');
    }
}