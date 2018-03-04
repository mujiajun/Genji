<template>
  <div>

    <el-select v-model="value" placeholder="全部" @change="queryArticle">
      <el-option v-for="item in options" :key="item.value" :label="item.label" :value="item.value">
      </el-option>
    </el-select>
    <el-row>
      <el-col :span="4" v-for="(o, index) in articleList.slice(0, 4)" :key="index" :offset="index > 0 ? 1 : 0">
        <el-card :body-style="{ padding: '0px' }">
          <img src="../../../assets/images/header.jpg" class="image">
          <div style="padding: 10px;">
            <span>{{o.title}}</span>
            <div class="bottom clearfix">
              <time class="time">{{o.createTime}}</time>
              <el-button type="text" class="button" @click="read(o.content)">阅 读</el-button>
            </div>
          </div>
        </el-card>
      </el-col>
    </el-row>
    <el-row>
      <el-col :span="4" v-for="(o, index) in articleList.slice(4)" :key="index" :offset="index > 0 ? 1 : 0">
        <el-card :body-style="{ padding: '0px' }">
          <img src="../../../assets/images/header.jpg" class="image">
          <div style="padding: 10px;">
            <span>{{o.title}}</span>
            <div class="bottom clearfix">
              <time class="time">{{ o.createTime }}</time>
              <el-button type="text" class="button" @click="read(o.content)">阅 读</el-button>
            </div>
          </div>
        </el-card>
      </el-col>
    </el-row>
    <div class="tags">
      <el-input v-model="query" placeholder="请输入内容"></el-input>
      <el-button class="btnquery" type="success" plain size="mini" icon="el-icon-search">全局搜索</el-button><br/>

      <span>-------------------------------------------</span>
      <div class="realTags">
        <el-tag>标签一</el-tag>
        <el-tag type="success">标签二</el-tag>
        <el-tag type="info">标签三</el-tag>
        <el-tag type="warning">标签四</el-tag>
        <el-tag type="danger">标签五</el-tag>
      </div>
      <span>-------------------------------------------</span>
      <div class="adarea">
        <el-card>
          <img src="../../../assets/images/heilongtan.jpg" class="image">
          <div style="padding: 14px;">
            <span>黑龙滩旅游</span>
            <div class="bottom clearfix">
              <el-button type="text" class="button">了解下</el-button>
            </div>
          </div>
        </el-card>
      </div>
    </div>
    <div class="xpagination">
      <el-button-group>
        <el-button type="primary" plain size="small" icon="el-icon-arrow-left">上一页</el-button>
        <el-button type="primary" plain size="small">下一页<i class="el-icon-arrow-right el-icon--right"></i></el-button>
      </el-button-group>
    </div>

    <template>
      <el-dialog fullscreen 
        center
        :modal="noShowModal"
        :visible.sync="dialogVisible"
        @close="closeone"
        @open="getone">
        <x-article  v-if="hackset"
                    :articleId="articleIndex"
                    ref="xarticle"></x-article>
      </el-dialog>
    </template>
  </div>
</template>


<script>
import article from "./article";
export default {
  name: "contentlist",
  components: {
    "x-article": article
  },
  data() {
    return {
      xpagination: {
        index: 0,
        size: 8
      },
      noShowModal: false,
      articleList: [],
      query: "",
      hackset: false,
      articleIndex: "",
      dialogVisible: false,
      currentDate: new Date(),
      options: [
        {
          value: "0",
          label: "全部"
        },
        {
          value: "选项1",
          label: "黄金糕"
        },
        {
          value: "选项2",
          label: "双皮奶"
        },
        {
          value: "选项3",
          label: "蚵仔煎"
        },
        {
          value: "选项4",
          label: "龙须面"
        },
        {
          value: "选项5",
          label: "北京烤鸭"
        }
      ],
      value: ""
    };
  },
  created() {
    this.getAll(this.xpagination);
  },
  methods: {
    read(content) {
      this.dialogVisible = true;
      this.articleIndex = content;
    },
    queryArticle() {
      alert(this.value);
    },
    closeone() {
      this.hackset = false;
      this.refs.xarticle.closeone();
    },
    getone() {
      this.hackset = true;
      this.refs.xarticle.getone();
    },
    getAll(xpagination) {
      this.$http
        .post("http://localhost:9817/api/Blog/getlist", this.xpagination)
        .then(res => {
          if (res.data.code === 20000) {
            this.articleList = res.data.data;
          } else {
            this.$message({
              message: res.data.message,
              type: "error"
            });
          }
        })
        .catch(() => {});
    }
  }
};
</script>

<style>
@media screen and (min-height: 768px) {
  .el-dialog__wrapper {
    position: fixed;
    top: 0;
    right: 20%;
    bottom: 0;
    overflow: auto;
    left: 15%;
    width: 66%;
  }
}

.adarea {
  margin-top: 20%;
}
.realTags {
  margin-top: 30px;
}
.realTags .el-tag {
  margin-top: 5px;
}

.btnquery {
  margin-left: 190px;
  margin-top: 10px;
}
.xpagination {
  width: 15%;
  height: 60px;
  position: fixed;
  right: 323px;
  top: 848x;
}
.el-select {
  margin-left: -81%;
  margin-top: 0px;
}
.tags {
  width: 15%;
  height: 850px;
  position: fixed;
  right: 30px;
  top: 40px;
}
.el-row {
  margin: 50px;
  /* margin-top: 30px;
  margin-bottom: 20px; */
}
.time {
  font-size: 13px;
  color: #999;
}

.bottom {
  margin-top: 13px;
  line-height: 12px;
}

.button {
  padding: 0;
  float: right;
}

.image {
  width: 100%;
  display: block;
}

.clearfix:before,
.clearfix:after {
  display: table;
  content: "";
}

.clearfix:after {
  clear: both;
}
</style>
