<template>
  <div>

    <el-select v-model="value" placeholder="全部" @change="queryArticle">
      <el-option v-for="item in options" :key="item.value" :label="item.label" :value="item.value">
      </el-option>
    </el-select>
    <el-row>
      <el-col :span="4" v-for="(o, index) in 4" :key="o" :offset="index > 0 ? 1 : 0">
        <el-card :body-style="{ padding: '0px' }">
          <img src="http://element.eleme.io/static/hamburger.50e4091.png" class="image">
          <div style="padding: 10px;">
            <span>好吃的汉堡</span>
            <div class="bottom clearfix">
              <time class="time">{{ currentDate }}</time>
              <el-button type="text" class="button" @click="read(index)">阅读</el-button>
            </div>
          </div>
        </el-card>
      </el-col>
    </el-row>
    <el-row>
      <el-col :span="4" v-for="(o, index) in 4" :key="o" :offset="index > 0 ? 1 : 0">
        <el-card :body-style="{ padding: '0px' }">
          <img src="http://element.eleme.io/static/hamburger.50e4091.png" class="image">
          <div style="padding: 10px;">
            <span>好吃的汉堡</span>
            <div class="bottom clearfix">
              <time class="time">{{ currentDate }}</time>
              <el-button type="text" class="button" @click="read(index)">阅 读</el-button>
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
        <el-button type="primary" icon="el-icon-arrow-left">上一页</el-button>
        <el-button type="primary">下一页<i class="el-icon-arrow-right el-icon--right"></i></el-button>
      </el-button-group>
    </div>

    <template>
      <el-dialog fullscreen
        :title="articleTitle"
        :visible.sync="dialogVisible">
        <span>{{articleIndex}}</span>
      </el-dialog>
    </template>
  </div>
</template>


<script>
export default {
  name: "contentlist",
  data() { 
    return {
      query: "",
      articleTitle: "",
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
  methods: {
    read(index) {
      this.dialogVisible = true;
      this.articleIndex = index;
      this.articleTitle = `标题${index}`;
    },
    queryArticle(){
      alert(this.value)
    }
  }
};
</script>

<style>
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
  right: 342px;
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
