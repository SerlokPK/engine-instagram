import Vue from "vue";
import VueI18n from "vue-i18n";
import { mapTranslations } from "../plugins/translationMapper";

Vue.use(VueI18n);

export default new VueI18n({
    locale: "en",
    messages: mapTranslations.locales()
});