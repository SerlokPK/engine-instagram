import AXIOS_CONSTANTS from '../../constants/axios';

export class BaseTransformer {
    constructor() {
      this.transform = this.transform.bind(this);
      this.transformSingle = this.transformSingle.bind(this);
      this.transformMultiple = this.transformMultiple.bind(this);
    }
  
    transform(payload) {
      const { errorMessage, statusCode } = payload;

      if (statusCode && statusCode >= AXIOS_CONSTANTS.BAD_REQUEST_STATUS_CODE) {
        return { errorMessage, statusCode };
      }
      let result = {};
  
      if (payload) {
        if ((Array.isArray(payload) || payload.length)) {
          result = this.transformMultiple(payload);
        } else {
          result = this.transformSingle(payload);
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