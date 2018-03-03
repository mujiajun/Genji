<template>
  <div>
    <el-container>
      
      <el-container>
        <el-aside>
          <div>
            <img id="xbackground" src="../../../assets/images/header.jpg" />
          </div>
          <div class="xnav">
            <h1>徐 程 意</h1>
            <p>CSharp Progarmmer</p><br/>
            <div>
              <a href="https://www.xuxuzhaozhao.top" target="_blank">
                <p class="zhuangbi"><i class="fa fa-home"></i>&nbsp;&nbsp;首&nbsp;页</p>
              </a>
              <a href="https://blog.xuxuzhaozhao.top" target="_blank">
                <p class="zhuangbi"><i class="fa fa-file-code-o"></i>&nbsp;&nbsp;文&nbsp;章</p>
              </a>
              <a href="https://www.xuxuzhaozhao.top/tools" target="_blank">
                <p class="zhuangbi"><i class="fa fa-th-large"></i>&nbsp;&nbsp;工&nbsp;具</p>
              </a>
              <a href="https://www.xuxuzhaozhao.top/advice" target="_blank">
                <p class="zhuangbi"><i class="fa fa-inbox"></i>&nbsp;&nbsp;留&nbsp;言</p>
              </a>
            </div><br/>
            <a href="https://www.xuxuzhaozhao.top/resume" target="_blank">
                <p style="margin-left:-20px;"><i class="fa fa-user-circle-o"></i>&nbsp;&nbsp;关于我</p>
              </a>
          </div>
          <div class="xlink">
            <a href="https://www.google.com" target="_blank">
              <i class="fa fa-google fa-2x"></i>
            </a>
            <a href="https://github.com/xuxuzhaozhao" target="_blank">
              <i class="fa fa-github fa-2x"></i>
            </a>
            <a href="http://github.com/xuxuzhaozhao" target="_blank">
              <i class="fa fa-weibo fa-2x"></i>
            </a>
            <a href="http://github.com/xuxuzhaozhao" target="_blank">
              <i class="fa fa-qq fa-2x"></i>
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
.fa{
  margin-left: 15px;
}
.zhuangbi{
  margin-left: -20px;
  margin-top: 15px;
}
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
    width: 15% !important;
  }
}
</style>
