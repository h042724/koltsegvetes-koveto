(function(){"use strict";var t={680:function(t,e,n){var a=n(963),s=n(252);function o(t,e){const n=(0,s.up)("router-link"),a=(0,s.up)("router-view");return(0,s.wg)(),(0,s.iD)(s.HY,null,[(0,s._)("nav",null,[(0,s.Wm)(n,{to:"/"},{default:(0,s.w5)((()=>[(0,s.Uk)("Home")])),_:1}),(0,s.Uk)(" | "),(0,s.Wm)(n,{to:{name:"About"}},{default:(0,s.w5)((()=>[(0,s.Uk)("About")])),_:1}),(0,s.Uk)(" | "),(0,s.Wm)(n,{to:{name:"IndexExpenses"}},{default:(0,s.w5)((()=>[(0,s.Uk)("Expenses")])),_:1})]),(0,s.Wm)(a)],64)}var l=n(744);const r={},i=(0,l.Z)(r,[["render",o]]);var u=i,c=n(201),d=n(577);const p=(0,s._)("div",{class:"home"},[(0,s._)("h1",null,"Homepage")],-1),m={class:"post"},f={key:0,class:"loading"},h=(0,s._)("a",{href:"https://aka.ms/jspsintegrationvue"},"https://aka.ms/jspsintegrationvue",-1),_={key:1,class:"content"},v=(0,s._)("thead",null,[(0,s._)("tr",null,[(0,s._)("th",null,"Date"),(0,s._)("th",null,"Temp. (C)"),(0,s._)("th",null,"Temp. (F)"),(0,s._)("th",null,"Summary")])],-1);function g(t,e,n,a,o,l){return(0,s.wg)(),(0,s.iD)(s.HY,null,[p,(0,s._)("div",m,[o.loading?((0,s.wg)(),(0,s.iD)("div",f,[(0,s.Uk)(" Loading... Please refresh once the ASP.NET backend has started. See "),h,(0,s.Uk)(" for more details. ")])):(0,s.kq)("",!0),o.post?((0,s.wg)(),(0,s.iD)("div",_,[(0,s._)("table",null,[v,(0,s._)("tbody",null,[((0,s.wg)(!0),(0,s.iD)(s.HY,null,(0,s.Ko)(o.post,(t=>((0,s.wg)(),(0,s.iD)("tr",{key:t.date},[(0,s._)("td",null,(0,d.zw)(t.date),1),(0,s._)("td",null,(0,d.zw)(t.temperatureC),1),(0,s._)("td",null,(0,d.zw)(t.temperatureF),1),(0,s._)("td",null,(0,d.zw)(t.summary),1)])))),128))])])])):(0,s.kq)("",!0)])],64)}var w={name:"HomeView",components:{},data(){return{loading:!1,post:null}},created(){this.fetchData()},watch:{$route:"fetchData"},methods:{fetchData(){this.post=null,this.loading=!0,fetch("weatherforecast").then((t=>t.json())).then((t=>{this.post=t,this.loading=!1}))}}};const k=(0,l.Z)(w,[["render",g]]);var b=k;const D={class:"about"},x=(0,s._)("h1",null,"This is an about page",-1),y=[x];function E(t,e){return(0,s.wg)(),(0,s.iD)("div",D,y)}const U={},O=(0,l.Z)(U,[["render",E]]);var C=O;const j={id:"expense"},z=(0,s._)("h1",null,"Expense Index - Vue",-1),T={class:"post"},P={key:0,class:"loading"},W=(0,s._)("a",{href:"https://aka.ms/jspsintegrationvue"},"https://aka.ms/jspsintegrationvue",-1),H={key:1,class:"content"},I=(0,s._)("thead",null,[(0,s._)("tr",null,[(0,s._)("th",null,"id"),(0,s._)("th",null,"name"),(0,s._)("th",null,"amount ($)"),(0,s._)("th",null,"date")])],-1);function V(t,e,n,a,o,l){const r=(0,s.up)("router-link");return(0,s.wg)(),(0,s.iD)("div",j,[z,(0,s._)("p",null,[(0,s.Wm)(r,{to:{name:"CreateExpenses"}},{default:(0,s.w5)((()=>[(0,s.Uk)("Create new")])),_:1})]),(0,s._)("div",T,[o.loading?((0,s.wg)(),(0,s.iD)("div",P,[(0,s.Uk)(" Loading... Please refresh once the ASP.NET backend has started. See "),W,(0,s.Uk)(" for more details. ")])):(0,s.kq)("",!0),o.post?((0,s.wg)(),(0,s.iD)("div",H,[(0,s._)("table",null,[I,(0,s._)("tbody",null,[((0,s.wg)(!0),(0,s.iD)(s.HY,null,(0,s.Ko)(o.post,(t=>((0,s.wg)(),(0,s.iD)("tr",{key:t.id},[(0,s._)("td",null,(0,d.zw)(t.id),1),(0,s._)("td",null,(0,d.zw)(t.name),1),(0,s._)("td",null,(0,d.zw)(t.amount),1),(0,s._)("td",null,(0,d.zw)(t.TransactionDate),1),(0,s._)("td",null,[(0,s.Wm)(r,{to:{name:"EditExpenses",params:{id:t.id}}},{default:(0,s.w5)((()=>[(0,s.Uk)("Edit")])),_:2},1032,["to"]),(0,s.Uk)(" | "),(0,s.Wm)(r,{to:{name:"DetailsExpenses",params:{id:t.id}}},{default:(0,s.w5)((()=>[(0,s.Uk)("Details")])),_:2},1032,["to"]),(0,s.Uk)(" | "),(0,s.Wm)(r,{to:{name:"DeleteExpenses",params:{id:t.id}}},{default:(0,s.w5)((()=>[(0,s.Uk)("Delete")])),_:2},1032,["to"])])])))),128))])])])):(0,s.kq)("",!0)])])}var Z={name:"IndexView",components:{},data(){return{loading:!1,post:null}},created(){this.fetchData()},watch:{$route:"fetchData"},methods:{fetchData(){this.post=null,this.loading=!0,fetch("expenses").then((t=>t.json())).then((t=>{this.post=t,this.loading=!1}))}}};const S=(0,l.Z)(Z,[["render",V]]);var $=S;const q={id:"expense"},A=(0,s._)("h1",null,"Expense Create - Vue",-1),N=["action"],Y=(0,s._)("div",{class:"row"},[(0,s._)("div",{class:"col-md-4"},[(0,s._)("div",{"asp-validation-summary":"ModelOnly",class:"text-danger"}),(0,s._)("div",{class:"form-group"},[(0,s._)("label",{for:"Name",class:"control-label"},"Név:"),(0,s._)("input",{name:"Name",class:"form-control"})]),(0,s._)("div",{class:"form-group"},[(0,s._)("label",{for:"Category",class:"control-label"},"Kategória:"),(0,s._)("input",{name:"Category",class:"form-control"})]),(0,s._)("div",{class:"form-group"},[(0,s._)("label",{for:"TransactionDate",class:"control-label"},"Tranzakció dátuma"),(0,s._)("input",{name:"TransactionDate",class:"form-control"})]),(0,s._)("div",{class:"form-group"},[(0,s._)("label",{for:"UserGuid",class:"control-label"},"User Guid"),(0,s._)("input",{name:"UserGuid",class:"form-control"})]),(0,s._)("div",{class:"form-group"},[(0,s._)("input",{type:"submit",value:"Create",class:"btn btn-primary"})])])],-1),F=[Y];function K(t,e,n,a,o,l){return(0,s.wg)(),(0,s.iD)("div",q,[A,(0,s._)("form",{action:t.CreateExpenseUrl,method:"post"},F,8,N)])}var L={};const R=(0,l.Z)(L,[["render",K]]);var G=R;const B={id:"app",class:"container"},J={key:0,class:"card"},M=(0,s._)("div",{class:"card-header"},"Vue Fetch POST",-1),Q={class:"form-group"},X=["value"],tt={class:"form-group"},et=["value"],nt={class:"form-group"},at=["value"],st={class:"form-group"},ot=["value"],lt={key:0,class:"alert alert-secondary mt-2",role:"alert"};function rt(t,e,n,a,o,l){return(0,s.wg)(),(0,s.iD)("div",B,[o.post?((0,s.wg)(),(0,s.iD)("div",J,[M,((0,s.wg)(!0),(0,s.iD)(s.HY,null,(0,s.Ko)(o.post,(t=>((0,s.wg)(),(0,s.iD)("div",{class:"card-body",key:t.id},[(0,s._)("div",Q,[(0,s._)("input",{type:"text",class:"form-control",ref_for:!0,ref:"post_id",value:t.id,disabled:""},null,8,X)]),(0,s._)("div",tt,[(0,s._)("input",{type:"text",class:"form-control",ref_for:!0,ref:"post_name",value:t.name},null,8,et)]),(0,s._)("div",nt,[(0,s._)("input",{type:"text",class:"form-control",ref_for:!0,ref:"post_amount",value:t.amount},null,8,at)]),(0,s._)("div",st,[(0,s._)("input",{type:"text",class:"form-control",ref_for:!0,ref:"post_transactionDate",value:t.transactionDate},null,8,ot)]),(0,s._)("button",{class:"btn btn-sm btn-primary",onClick:e[0]||(e[0]=(...t)=>l.postData&&l.postData(...t))},"Post Data"),(0,s._)("button",{class:"btn btn-sm btn-warning ml-2",onClick:e[1]||(e[1]=(...t)=>l.clearPostOutput&&l.clearPostOutput(...t))},"Clear"),o.postResult?((0,s.wg)(),(0,s.iD)("div",lt,[(0,s._)("pre",null,(0,d.zw)(o.postResult),1)])):(0,s.kq)("",!0)])))),128))])):(0,s.kq)("",!0)])}var it={name:"EditView",props:["id"],data(){return{loading:!1,post:null,postResult:null}},created(){this.fetchData()},watch:{$route:"fetchData"},methods:{fetchData(){this.post=null,this.loading=!0,fetch("https://localhost:7007/expenses/").then((t=>t.json())).then((t=>{this.post=t,this.loading=!1}))},async postData(){const t={name:this.$refs.post_name.value,amount:this.$refs.post_amount.value,transactionDate:this.$refs.post_transactionDate.value};try{await fetch("https://localhost:7007/expenses/",{method:"post",headers:{"Content-Type":"application/json"},body:JSON.stringify(t)}).then((function(e){console.log("ez a response "+e.json(t))})).then((function(t){console.log("ez a text "+t)})).catch((function(t){console.error(t)}))}catch(e){alert(e)}},clearPostOutput(){this.postResult=null}}};const ut=(0,l.Z)(it,[["render",rt]]);var ct=ut;const dt={id:"expense"},pt=(0,s._)("h1",null,"Expense delete - Vue",-1),mt=(0,s._)("h3",null,"Are you sure you want to delete this?",-1),ft={class:"row"},ht=(0,s._)("dt",{class:"col-sm-2"},[(0,s._)("label",null,"ID")],-1),_t={class:"col-sm-10"},vt={method:"post"},gt=(0,s._)("input",{type:"hidden",name:"id",value:"id"},null,-1),wt=(0,s._)("input",{type:"submit",value:"Delete",class:"btn btn-danger"},null,-1);function kt(t,e,n,a,o,l){const r=(0,s.up)("router-link");return(0,s.wg)(),(0,s.iD)("div",dt,[pt,mt,(0,s._)("dl",ft,[ht,(0,s._)("dd",_t,(0,d.zw)(n.id),1)]),(0,s._)("form",vt,[gt,wt,(0,s.Uk)(" | "),(0,s.Wm)(r,{to:{name:"IndexExpenses"}},{default:(0,s.w5)((()=>[(0,s.Uk)("Back to List")])),_:1})])])}var bt={props:["id"]};const Dt=(0,l.Z)(bt,[["render",kt]]);var xt=Dt;const yt={id:"expense"},Et=(0,s._)("h1",null,"Expense details - Vue",-1),Ut={class:"row"},Ot=(0,s._)("dt",{class:"col-sm-2"},[(0,s._)("label",null,"ID")],-1),Ct={class:"col-sm-10"};function jt(t,e,n,a,o,l){const r=(0,s.up)("router-link");return(0,s.wg)(),(0,s.iD)("div",yt,[Et,(0,s._)("dl",Ut,[Ot,(0,s._)("dd",Ct,(0,d.zw)(n.id),1)]),(0,s._)("div",null,[(0,s.Wm)(r,{to:{name:"EditExpenses",params:{id:n.id}}},{default:(0,s.w5)((()=>[(0,s.Uk)("Edit")])),_:1},8,["to"]),(0,s.Uk)(" | "),(0,s.Wm)(r,{to:{name:"IndexExpenses"}},{default:(0,s.w5)((()=>[(0,s.Uk)("Back to List")])),_:1})])])}var zt={props:["id"]};const Tt=(0,l.Z)(zt,[["render",jt]]);var Pt=Tt;const Wt=[{path:"/",name:"Home",component:b},{path:"/about",name:"About",component:C},{path:"/expenses",name:"IndexExpenses",component:$},{path:"/expenses/create",name:"CreateExpenses",component:G},{path:"/expenses/edit/:id",name:"EditExpenses",component:ct,props:!0},{path:"/expenses/delete/:id",name:"DeleteExpenses",component:xt,props:!0},{path:"/expenses/details/:id",name:"DetailsExpenses",component:Pt,props:!0}],Ht=(0,c.p7)({history:(0,c.PO)("/"),routes:Wt});var It=Ht;(0,a.ri)(u).use(It).mount("#app")}},e={};function n(a){var s=e[a];if(void 0!==s)return s.exports;var o=e[a]={exports:{}};return t[a](o,o.exports,n),o.exports}n.m=t,function(){var t=[];n.O=function(e,a,s,o){if(!a){var l=1/0;for(c=0;c<t.length;c++){a=t[c][0],s=t[c][1],o=t[c][2];for(var r=!0,i=0;i<a.length;i++)(!1&o||l>=o)&&Object.keys(n.O).every((function(t){return n.O[t](a[i])}))?a.splice(i--,1):(r=!1,o<l&&(l=o));if(r){t.splice(c--,1);var u=s();void 0!==u&&(e=u)}}return e}o=o||0;for(var c=t.length;c>0&&t[c-1][2]>o;c--)t[c]=t[c-1];t[c]=[a,s,o]}}(),function(){n.d=function(t,e){for(var a in e)n.o(e,a)&&!n.o(t,a)&&Object.defineProperty(t,a,{enumerable:!0,get:e[a]})}}(),function(){n.g=function(){if("object"===typeof globalThis)return globalThis;try{return this||new Function("return this")()}catch(t){if("object"===typeof window)return window}}()}(),function(){n.o=function(t,e){return Object.prototype.hasOwnProperty.call(t,e)}}(),function(){var t={143:0};n.O.j=function(e){return 0===t[e]};var e=function(e,a){var s,o,l=a[0],r=a[1],i=a[2],u=0;if(l.some((function(e){return 0!==t[e]}))){for(s in r)n.o(r,s)&&(n.m[s]=r[s]);if(i)var c=i(n)}for(e&&e(a);u<l.length;u++)o=l[u],n.o(t,o)&&t[o]&&t[o][0](),t[o]=0;return n.O(c)},a=self["webpackChunkvueapp"]=self["webpackChunkvueapp"]||[];a.forEach(e.bind(null,0)),a.push=e.bind(null,a.push.bind(a))}();var a=n.O(void 0,[998],(function(){return n(680)}));a=n.O(a)})();
//# sourceMappingURL=app.e28d603c.js.map