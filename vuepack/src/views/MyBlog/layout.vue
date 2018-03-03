<template>
  <div>
    <el-container>
      <el-header>徐徐赵赵</el-header>
      <el-container>
        <el-aside>
          <div>
            <img id="xbackground" src="http://element.eleme.io/static/hamburger.50e4091.png" />
          </div>
          <div class="xnav">
            <h1>xuxuzhaozhao</h1>
            <p>Charp Progarmmer</p><br/>
            <div>
              <a href="https://www.xuxuzhaozhao.top" target="_blank">
                <p>首页▪印象</p>
              </a>
              <a href="https://blog.xuxuzhaozhao.top" target="_blank">
                <p>文章▪类别</p>
              </a>
              <a href="https://www.xuxuzhaozhao.top/tools" target="_blank">
                <p>精品▪工具</p>
              </a>
              <a href="https://www.xuxuzhaozhao.top/advice" target="_blank">
                <p>留言▪建议</p>
              </a>
            </div>
          </div>
          <div class="xlink">
            <a href="http://github.com/xuxuzhaozhao" target="_blank">
              <i class="fa fa-github"></i>
            </a>
            <a href="http://github.com/xuxuzhaozhao" target="_blank">
              <i class="fa fa-github"></i>
            </a>
            <a href="http://github.com/xuxuzhaozhao" target="_blank">
              <i class="fa fa-github"></i>
            </a>
            <a href="http://github.com/xuxuzhaozhao" target="_blank">
              <i class="fa fa-github"></i>
            </a>
          </div>
        </el-aside>
        <el-container>
          <el-main>
            <content-list></content-list>
          </el-main>
          <el-footer>xuxuzhaozhao copyright © 2015 - 2018</el-footer>
        </el-container>
      </el-container>
    </el-container>
  </div>
</template>

<script>
import contentlist from "./index";
export default {
  components: {
    "content-list": contentlist
  }
};
</script>

<style>
.xnav {
  margin-bottom: 20%;
}
#xbackground {
  width: 100%;
  height: 30%;
}
.el-header {
  position: fixed;
  width: 100%;
  background-color: #b3c0d1;
  color: #333;
  text-align: center;
  line-height: 40px;
  height: 40px !important;
}
.el-footer {
  background-color: #b3c0d1;
  color: #333;
  text-align: center;
  line-height: 20px;
  font-family: "Segoe UI", Tahoma, Geneva, Verdana, sans-serif;
  font-size: 0.1em;
  height: 20px !important;
}
.el-aside {
  background-color: #d3dce6;
  color: #333;
  text-align: center;
}

.el-main {
  background-color: #e9eef3;
  color: #333;
  text-align: center;
}

.el-container {
  min-height: calc(100vh - 0px);
}

@media screen and (max-width: 768px) {
  .el-aside {
    width: 0% !important;
  }
}

@media screen and (min-width: 768px) {
  .el-aside {
    width: 20% !important;
  }
}
</style>
