export const mapTranslations = { 
    locales() {
      const requireContext = require.context("../locales", true, /.*\.json$/);
      const result = requireContext
        .keys()
        .map(file => [
          file.replace(/(^.\/)|(\.json$)/g, ""),
          requireContext(file)
        ])
        .reduce((modules, [name, module]) => {
          module.namespaced = true;
          modules[name] = module;
          return modules;
        }, {});
  
      return { ...result };
    }
  };