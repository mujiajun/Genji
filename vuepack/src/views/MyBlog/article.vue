<template>
  <div>
      <span>
          <markdown v-if="hackset"
                    :mdValuesP="editContent.content" 
                    :fullPageStatusP="false" 
                    :editStatusP="false" 
                    :previewStatusP="true" 
                    :navStatusP="false" 
                    :icoStatusP="false">
          </markdown>
        </span>
  </div>
</template>

<script>
import markdown from "@/components/Markdown/index";

export default {
  props: {
    articleId: {
      type: Number,
      default: 6
    }
  },
  components: {
    markdown
  },
  data() {
    return {
      hackset: false,
      editContent: {}
    };
  },
  created() {
    this.getone();
  },
  methods: {
    getone() {
      this.editContent.content = this.articleId;
      this.hackset = true;
      // this.$http
      //   .get(`http://localhost:9817/api/Blog/getone?id=${this.articleId}`)
      //   .then(res => {
      //     if (res.data.code === 20000) {
      //       this.editContent = res.data.data;
      //       this.hackset = true;
      //     } else {
      //       this.editContent.content = "文章被删除了,[惊吓]";
      //       this.hackset = true;
      //     }
      //   });
    },
    closeone() {
      this.hackset = false;
    }
  }
};
</script>

<style>

</style>
