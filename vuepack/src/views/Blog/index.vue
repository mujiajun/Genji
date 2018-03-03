<template>
  <div>
    <el-button type="success" id="addBlog" @click="dialogVisible = true">新增</el-button>
    <el-table :data="tableData" border style="width: 99%;margin:10px;">
      <el-table-column prop="title" label="标题" width="150">
      </el-table-column>
      <el-table-column prop="category" label="分类" width="120">
      </el-table-column>
      <el-table-column prop="tag" label="标签" width="120">
      </el-table-column>
      <el-table-column prop="content" label="正文" show-overflow-tooltip>
      </el-table-column>
      <el-table-column prop="readCount" label="阅读量" width="80">
      </el-table-column>
      <el-table-column prop="createTime" label="创建日期" width="150">
      </el-table-column>
      <el-table-column prop="modifiedTime" label="修改日期" width="150">
      </el-table-column>
      <el-table-column fixed="right" label="操作" width="150">
        <template slot-scope="scope">
          <el-button @click="handleClick(scope.row)" type="text" size="small">查看</el-button>
          <el-button @click="dialogEditVisible1(scope.row)" type="text" size="small">编辑</el-button>
          <el-button @click="deleteArticle(scope.row)" type="text" size="small" style="color:red;">删除</el-button>
        </template>
      </el-table-column>
    </el-table>

    <template>
      <el-dialog title="添加文章" :visible.sync="dialogVisible" width="95%">
        <el-row :gutter="10">
          <el-col :span="6">
            <el-input v-model="content.Title" placeholder="请输入标题"></el-input>
          </el-col>
          <el-col :span="6">
            <el-input v-model="content.Tag" placeholder="请输入标签(以空格分开)"></el-input>
          </el-col>
          <el-col :span="6">
            <el-select v-model="content.Category" placeholder="请选择文章分类">
              <el-option v-for="item in options" :key="item.value" :label="item.label" :value="item.value">
              </el-option>
            </el-select>
          </el-col>
        </el-row>
        <span>
          <markdown :mdValuesP="content.Content" :fullPageStatusP="false" :editStatusP="true" :previewStatusP="true" :navStatusP="true" :icoStatusP="true" @childevent="childEventHandler">
          </markdown>
        </span>
        <span slot="footer" class="dialog-footer">
          <el-button @click="dialogVisible = false">取 消</el-button>
          <el-button type="primary" @click="addNewArticle">新 增</el-button>
        </span>
      </el-dialog>
    </template>

    <template>
      <el-dialog title="编辑文章" :visible.sync="dialogEditVisible" width="95%" @close='closeDialog' @open='openDialog'>
        <el-row :gutter="10">
          <el-col :span="6">
            <el-input v-model="editContent.title" placeholder="请输入标题"></el-input>
          </el-col>
          <el-col :span="6">
            <el-input v-model="editContent.tag" placeholder="请输入标签(以空格分开)"></el-input>
          </el-col>
          <el-col :span="6">
            <el-select v-model="editContent.category" placeholder="请选择文章分类">
              <el-option v-for="item in options" :key="item.value" :label="item.label" :value="item.value">
              </el-option>
            </el-select>
          </el-col>
        </el-row>
        <span>
          <markdown v-if="hackReset" :mdValuesP="editContent.content" :fullPageStatusP="false" :editStatusP="true" :previewStatusP="true" :navStatusP="true" :icoStatusP="true" @childevent="childEditEventHandler" ref="setArticle">
          </markdown>
        </span>
        <span slot="footer" class="dialog-footer">
          <el-button @click="dialogEditVisible = false">取 消</el-button>
          <el-button type="primary" @click="editArticle">确认修改</el-button>
        </span>
      </el-dialog>
    </template>
  </div>
</template>

<script>
import { getBlogList, addNewBlog } from "@/api/blog";
import markdown from "@/components/Markdown/index";

export default {
  components: {
    markdown: markdown
  },
  methods: {
    handleClick(row) {
      console.log(row);
    }
  },

  data() {
    return {
      hackReset: false,
      content: {
        Content: "## Vue-markdownEditor",
        Title: "",
        Tag: "",
        Category: ""
      },
      dialogVisible: false,
      editContent: {
        content: "",
        title: "",
        tag: "",
        category: ""
      },
      resEdit: {
        mdValue: ""
      },
      dialogEditVisible: false,
      tableData: [],
      options: [
        {
          value: 1,
          label: "C#"
        }
      ]
    };
  },
  created() {
    this.getBlogList();
  },
  methods: {
    getBlogList() {
      //this.listLoading = true;
      getBlogList().then(response => {
        //console.log(this.listQuery);
        this.tableData = response.data;
        //this.listLoading = false;
        console.log(response.data);
      });
    },
    addNewArticle() {
      this.dialogVisible = false;
      console.log(this.content);
      this.$http
        .post("http://localhost:9817/api/blog", this.content)
        .then(res => {
          console.log(res);
          if (res.data.code == 20000) {
            this.$message({
              message: res.data.message,
              type: "success"
            });
            this.getBlogList();
          }
        });
    },
    deleteArticle(row) {
      this.$confirm(`确定删除文章<<${row.title}>>, 是否继续?`, "提示", {
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        type: "warning"
      })
        .then(() => {
          this.$http
            .delete(`http://localhost:9817/api/blog/${row.id}`)
            .then(res => {
              if (res.data.code === 20000) {
                this.$message({
                  type: "success",
                  message: "删除成功!"
                });
                this.getBlogList();
              } else {
                this.$message({
                  type: "fatal",
                  message: "删除失败!"
                });
              }
            });
        })
        .catch(() => {});
    },
    dialogEditVisible1(row) {
      this.editContent = row;
      this.dialogEditVisible = true;
    },
    editArticle() {
      this.dialogEditVisible = false;
      this.$http
        .put(`http://localhost:9817/api/blog/${this.editContent.id}`, this.editContent)
        .then(res => {
          if (res.data.code === 20000) {
            this.$message({
              type: "success",
              message: "更新成功!"
            });
          } else {
            this.$message({
              type: "fatal",
              message: "更新失败!"
            });
          }
        });
    },
    closeDialog() {
      this.dialogEditVisible = false;

      //强制摧毁子组件,让值恢复初始化(v-if 在切换时，元素及它的绑定数据和组件都会被销毁并重建)
      this.hackReset = false;
    },
    openDialog() {
      this.hackReset = true;
    },
    // 监听事件，接收子组件传过来的数据
    childEventHandler: function(res) {
      // res会传回一个data,包含属性mdValue和htmlValue，具体含义请自行翻译
      this.content.Content = res.mdValue;
    },
    // 监听事件，接收子组件传过来的数据
    childEditEventHandler: function(res) {
      // res会传回一个data,包含属性mdValue和htmlValue，具体含义请自行翻译
      this.editContent.content = res.mdValue;
    }
  }
};
</script>

<style>
#addBlog {
  margin-top: 10px;
  margin-left: 10px;
}
.el-dialog {
  margin-top: 2vh !important;
}
.el-dialog__body {
  padding-top: 5px;
  height: 830px;
}
.el-table__body-wrapper {
  overflow: hidden;
  position: relative;
}
</style>
