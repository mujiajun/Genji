const content = {
  state: {
    article: ''
  },

  mutations: {
    SET_CONTENT: (state, article) => {
      state.article = article
    }
  },

  actions: {
    SetCount({ commit }, article) {
      return new Promise((resolve, reject) => {
        commit('SET_CONTENT', article)
        resolve()
      })
    }
  }
}

export default content
