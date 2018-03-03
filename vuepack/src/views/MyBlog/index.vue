<template>
  <div>

    <el-select v-model="value" placeholder="全部">
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
              <el-button type="text" class="button">操作按钮</el-button>
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
              <el-button type="text" class="button">操作按钮</el-button>
            </div>
          </div>
        </el-card>
      </el-col>
    </el-row>
    <div class="tags">

    </div>
    <div class="xpagination">

    </div>
  </div>
</template>

<style>
.xpagination{
  width: 10%;
  height: 60px;
  background-color: rgb(255, 127, 127);
  position: fixed;
  right: 360px;
  top: 860px;
}
.el-select {
  margin-left: -80%;
  margin-top: 51px;
}
.tags {
  width: 15%;
  height: 850px;
  background-color: aquamarine;
  position: fixed;
  right: 30px;
  top: 71px;
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

<script>
export default {
  name: "contentlist",
  data() {
    return {
      currentDate: new Date(),
      options: [
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
  }
};
</script>